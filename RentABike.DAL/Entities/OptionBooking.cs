using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentAVehicle.DAL.Entities
{
    public class OptionBooking
    {
        public OptionBooking()
        {
            OptionBookingBookings = new HashSet<OptionBookingBooking>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsFixedPrice { get; set; }

        public decimal PriceValue { get; set; }

        public virtual ICollection<OptionBookingBooking> OptionBookingBookings { get; set; }
    }
}
