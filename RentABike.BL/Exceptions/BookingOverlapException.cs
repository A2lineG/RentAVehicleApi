using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendAVehicle.BL.Exceptions
{
    public class BookingOverlapException : Exception
    {
        public BookingOverlapException() : base("Une réservation existe déjà dans tranche de dates.")
        {
            
        }
    }
}
