using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAVehicle.BL.Exceptions
{
    class DaysBeforeCancelBookingException : Exception
    {
        public DaysBeforeCancelBookingException() : base("Vous ne pouvez pas annuler une réservation qui démarre dans moins de 7 jours.")
        {

        }
    }
}
