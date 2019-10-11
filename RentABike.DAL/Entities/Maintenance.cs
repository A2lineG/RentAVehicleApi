using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class Maintenance
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Comment { get; set; }

        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
