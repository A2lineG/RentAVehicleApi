using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class Vehicle
    {
        public Vehicle()
        {
            Bookings = new HashSet<Booking>();
            Opinions = new HashSet<Opinion>();
            OptionVehicleVehicles = new HashSet<OptionVehicleVehicle>();
            Maintenances = new HashSet<Maintenance>();
        }

        [Key]
        public Guid Id { get; set; }

        public int Year { get; set; }

        public int Mileage { get; set; }

        public string ChassisNumber { get; set; }

        public string PlateNumber { get; set; }

        [ForeignKey("Model")]
        public Guid ModelId { get; set; }

        public Model Model { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }

        public virtual ICollection<OptionVehicleVehicle> OptionVehicleVehicles { get; set; }

        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
