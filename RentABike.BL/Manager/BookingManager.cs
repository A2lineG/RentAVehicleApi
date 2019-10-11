using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using RendAVehicle.BL.Exceptions;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Exceptions;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class BookingManager : BaseManager
    {
        private const string StatusDraft = "Brouillon";
        private const string StatusBook = "Réservé";
        private const string StatusOngoing = "En cours";
        private const string StatusDone = "Terminé";
        private const string StatusCancel = "Annulé";

        /// <summary>
        /// GET
        /// </summary>
        public List<BookingDTO> GetBookingList()
        {
            var modelMapper = _dbContext.Bookings
                .Include(a => a.Vehicle.Model.Brand)
                .Include(d => d.Client)
                .Include(e => e.Depot)
                .ToList();

            List<BookingDTO> booking = _mapper.Map<List<BookingDTO>>(modelMapper);

            return booking;

        }

        /// <summary>
        /// GET
        /// </summary>
        public List<BookingDTO> GetBookingListByVehicleOrClient(Guid vehicleId, Guid clientId)
        {
            var modelMapper = _dbContext.Bookings
                .Include(a => a.Vehicle.Model.Brand)
                .Include(d => d.Client)
                .Include(e => e.Depot)
                .Where(x => (x.VehicleId == vehicleId || x.ClientId == clientId) && x.Status != StatusCancel)
                .ToList();

            List<BookingDTO> booking = _mapper.Map<List<BookingDTO>>(modelMapper);

            return booking;

        }

        /// <summary>
        /// get
        /// </summary>
        // GET
        public List<BookingDTO> GetBookingByClient(Guid clientId)
        {
            var modelMapper = _dbContext.Bookings
                .Include(b => b.Vehicle.Model.Brand)
                .Include(c => c.Depot)
                .Include(e => e.Client)
                .Where(x => x.ClientId == clientId)
                .ToList();

            List<BookingDTO> booking = _mapper.Map<List<BookingDTO>>(modelMapper);

            return booking;
        }

        /// <summary>
        /// Get detail booking
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>

        public BookingDTO GetBookingDetailByClient(Guid bookingId)
        {
            var modelMapper = _dbContext.Bookings
                .Include(a => a.Vehicle.Model)
                .Include(b => b.Vehicle.Model.Brand)
                .Include(c => c.Depot)
                .Include(d => d.OptionBookingBookings.Select(e => e.OptionBooking))
                .Include(e => e.Client)
                .FirstOrDefault(x => x.Id == bookingId);

            BookingDTO booking = _mapper.Map<BookingDTO>(modelMapper);

            return booking;
        }

        /// <summary>
        /// INSERT
        /// </summary>
        public Guid InsertBooking(BookingDTO bookingDto)
        {
            var client = _dbContext.Clients.SingleOrDefault(x => x.Id == bookingDto.ClientId);
            if (client == null)
            {
                throw new Exception("Client not found");
            }

            var vehicle = _dbContext.Vehicles.Include(x => x.Model).SingleOrDefault(x => x.Id == bookingDto.VehicleID);
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found");
            }

            //exceptions ************************************
            if (bookingDto.StartDate > bookingDto.EndDate)
            {
                throw new DatesException();
            }

            var otherBooking = _dbContext.Bookings.FirstOrDefault(x => x.StartDate < bookingDto.EndDate && x.EndDate > bookingDto.StartDate && x.ClientId == bookingDto.ClientId && x.Status != StatusCancel);

            if (otherBooking != null)
            {
                throw new BookingOverlapException();
            }

            var otherBooking2 = _dbContext.Bookings.FirstOrDefault(x => x.StartDate < bookingDto.EndDate && x.EndDate > bookingDto.StartDate && x.VehicleId == bookingDto.VehicleID && x.Status != StatusCancel);

            if (otherBooking2 != null)
            {
                throw new VehicleBookedException();
            }
            
            //price total ******************************
            decimal priceOptionBooking = 0;

            if (bookingDto.OptionBookingBookings != null)
            {
                foreach (var optionBooking in bookingDto.OptionBookingBookings)
                {
                    if (optionBooking.OptionBooking.IsFixedPrice == false)
                    {
                        priceOptionBooking += (optionBooking.OptionBooking.PriceValue > 0
                                                  ? optionBooking.OptionBooking.PriceValue / 100
                                                  : 0) * (
                                                  vehicle.Model.Price);
                    }
                    else
                    {
                        priceOptionBooking += optionBooking.OptionBooking.PriceValue;
                    }
                }
            }
            
            decimal pourcentageToAddAge = 0;

            int age = DateTime.Today.Year - client.BirthDate.Year;

            AgeCoefficient ageCoefficient = _dbContext.AgeCoefficients.FirstOrDefault(x => x.StartAge <= age && x.EndAge >= age);

            if (ageCoefficient != null) 
            {
                pourcentageToAddAge = ageCoefficient.Percentage == 0 ? 0 : ageCoefficient.Percentage / 100;
            }

            decimal pourcentageToAddPeriod = 0;

            PeriodCoefficient periodCoefficient = _dbContext.PeriodCoefficients.FirstOrDefault(x =>
                x.StartDate <= bookingDto.StartDate && x.EndDate >= bookingDto.EndDate);

            if (periodCoefficient != null)
            {
                pourcentageToAddPeriod = periodCoefficient.Percentage == 0 ? 0 : periodCoefficient.Percentage / 100;
            }

            var vehiclePrice = vehicle.Model.Price + priceOptionBooking;

            var totalPrice = vehiclePrice * ((decimal)(bookingDto.EndDate - bookingDto.StartDate).TotalDays +1) +
                         vehiclePrice * pourcentageToAddAge +
                         vehiclePrice * pourcentageToAddPeriod;

            //create booking
            var bookingNb = _dbContext.Bookings.Any() ? _dbContext.Bookings.Max(x => x.Number) +1 : 1;

            Booking booking = new Booking
            {
                Id = Guid.NewGuid(),
                ClientId = bookingDto.ClientId,
                Status = StatusDraft,
                Number = bookingNb,
                AgeCoefficientId = ageCoefficient?.Id,
                DepotId = bookingDto.DepotId,
                StartDate = bookingDto.StartDate,
                EndDate = bookingDto.EndDate,
                TotalPrice = totalPrice,
                VehicleId = bookingDto.VehicleID,
                PeriodCoefficientId = periodCoefficient?.Id
            };

            _dbContext.Bookings.Add(booking);

            //add options
            if (bookingDto.OptionBookingBookings != null)
            {
                foreach (var option in bookingDto.OptionBookingBookings)
                {
                    _dbContext.OptionBookingBookings.Add(new OptionBookingBooking()
                    {
                        Id = Guid.NewGuid(),
                        BookingId = booking.Id,
                        OptionBookingId = option.OptionBooking.Id
                    });
                }
            }

            _dbContext.SaveChanges();
            return booking.Id;
        }
        

        /// <summary>
        /// UPDATE
        /// </summary>
        // UPDATE
        public BookingDTO UpdateStatusBooking(Guid bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(x => x.Id == bookingId);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            switch (booking.Status)
            {
                case StatusDraft:
                    booking.Status = StatusBook;
                    break;
                case StatusBook:
                    booking.Status = StatusOngoing;
                    break;
                case StatusOngoing:
                    booking.Status = StatusDone;
                    break;
                default:
                    return _mapper.Map<BookingDTO>(booking);
            }

            _dbContext.SaveChanges();

            return _mapper.Map<BookingDTO>(booking);
        }

        /// <summary>
        /// Validate
        /// </summary>
        public BookingDTO ValidateBooking(Guid bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(x => x.Id == bookingId);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            booking.Status = StatusBook;

            _dbContext.SaveChanges();

            return _mapper.Map<BookingDTO>(booking);
        }

        /// <summary>
        /// DELETE
        /// </summary>
        public BookingDTO CancelBooking(Guid bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(x => x.Id == bookingId);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            if (booking.Status != StatusDraft && (booking.StartDate - DateTime.Now).TotalDays < 7)
            {
                throw new DaysBeforeCancelBookingException();
            }

            booking.Status = StatusCancel;

            _dbContext.SaveChanges();

            return _mapper.Map<BookingDTO>(booking);
        }
    }
}
