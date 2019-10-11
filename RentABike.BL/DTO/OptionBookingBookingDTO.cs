using System;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.DTO
{
    public class OptionBookingBookingDTO
    {
        public Guid Id { get; set; }

        public BookingDTO Booking { get; set; }

        public OptionBookingDTO OptionBooking { get; set; }
    }
}
