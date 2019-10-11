using System;

namespace RentAVehicle.BL.DTO
{
    public class PeriodCoefficientDTO
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Percentage { get; set; }
    }
}
