using System;
using System.Collections.Generic;

namespace RentAVehicle.BL.DTO
{
    public class OptionBookingDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsFixedPrice { get; set; }

        public decimal PriceValue { get; set; }

        public string PriceString => IsFixedPrice ? $"{PriceValue}€" : $"{PriceValue}% du prix du véhicule";

        //public List<OptionBookingBookingDTO> OptionBookingBookings { get; set; }
    }
}
