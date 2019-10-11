using System;

namespace RentAVehicle.BL.DTO
{
    public class AgeCoefficientDTO
    {
        public Guid Id { get; set; }

        public int StartAge { get; set; }

        public int EndAge { get; set; }

        public decimal Percentage { get; set; }
    }
}
