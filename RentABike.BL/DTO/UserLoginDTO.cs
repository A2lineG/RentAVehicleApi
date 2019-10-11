using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAVehicle.BL.DTO
{
    public class UserLoginDTO
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public List<string> Roles { get; set; }
    }
}
