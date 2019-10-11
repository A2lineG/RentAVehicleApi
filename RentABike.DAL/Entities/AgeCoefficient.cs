using System;
using System.ComponentModel.DataAnnotations;

namespace RentAVehicle.DAL.Entities
{
    public class AgeCoefficient
    {
        [Key]
        public Guid Id { get; set; }

        public int StartAge { get; set; }

        public int EndAge { get; set; }

        public decimal Percentage { get; set; }
    }
}
