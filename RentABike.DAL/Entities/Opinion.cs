using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class Opinion
    {
        [Key]
        public Guid Id { get; set; }

        public string Comment { get; set; }

        public decimal Rating { get; set; }


        [ForeignKey("Client")]
        public Guid ClientId { get; set; }

        public Client Client { get; set; }


        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
