using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendAVehicle.BL.Exceptions
{
    public class DatesException : Exception
    {
        public DatesException() : base("La date de début doit être supérieure à la date de fin.")
        {
            
        }
    }
}
