using System;
using System.Collections.Generic;
using RentAVehicle.BL.DTO;

namespace RentAVehicle.BL.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }

        public Guid PeriodCoefficientId { get; set; }

        public Guid DepotId { get; set; }

        public Guid VehicleID { get; set; }

        public Guid ClientId { get; set; }

        public VehicleDTO Vehicle { get; set; }

        public PeriodCoefficientDTO PeriodCoefficient { get; set; }

        public AgeCoefficientDTO AgeCoefficient { get; set; }

        public ClientDTO Client { get; set; }

        public DepotDTO Depot { get; set; }

        public List<OptionBookingBookingDTO> OptionBookingBookings { get; set; }

    }
}
