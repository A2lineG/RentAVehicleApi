using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAVehicle.DAL.Entities
{
    public class OptionBookingBooking
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("Booking")]
        public Guid BookingId { get; set; }

        public Booking Booking { get; set; }


        [ForeignKey("OptionBooking")]
        public Guid OptionBookingId { get; set; }

        public OptionBooking OptionBooking { get; set; }
    }
}
