using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class PeriodCoefficient
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public decimal Percentage { get; set; }
    }
}
