using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendAVehicle.BL.Exceptions
{
    public class VehicleBookedException: Exception
    {
        public VehicleBookedException(): base("Ce véhicle est déjà réservé dans cette période.")
        {
            
        }
    }
}
