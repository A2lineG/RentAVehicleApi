using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class Booking
    {
        public Booking()
        {
            OptionBookingBookings = new HashSet<OptionBookingBooking>();
        }

        [Key]
        public Guid Id { get; set; }

        public int Number { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }


        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }


        [ForeignKey("PeriodCoefficient")]
        public Guid? PeriodCoefficientId { get; set; }

        public PeriodCoefficient PeriodCoefficient { get; set; }


        [ForeignKey("AgeCoefficient")]
        public Guid? AgeCoefficientId { get; set; }

        public AgeCoefficient AgeCoefficient { get; set; }


        [ForeignKey("Client")]
        public Guid ClientId { get; set; }

        public Client Client { get; set; }


        [ForeignKey("Depot")]
        public Guid DepotId { get; set; }

        public Depot Depot { get; set; }

        public virtual ICollection<OptionBookingBooking> OptionBookingBookings { get; set; }


    }
}
