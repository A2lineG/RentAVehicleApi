using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentAVehicle.BL.DTO;
using RentAVehicle.DAL;
using RentAVehicle.DAL.Entities;

namespace RentAVehicle.BL.Manager
{
    public class AuthManager : IDisposable
    {
        private RentAVehicleDB _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthManager()
        {
            _ctx = new RentAVehicleDB();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(AuthDTO userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Email
            };

            _ctx.Clients.Add(new Client()
            {
                Id = Guid.NewGuid(),
                FirstName = userModel.FirstName,
                Surname = userModel.Surname,
                Email = userModel.Email,
                BirthDate = userModel.BirthDate,
                DriverLicenseNumber = userModel.DriverLicenseNumber
            });

            var result = await _userManager.CreateAsync(user, userModel.Password);

            await _userManager.AddToRoleAsync(user.Id, "user");

            await _ctx.SaveChangesAsync();

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<IdentityUser> GetUserByName(string userName)
        {
            IdentityUser user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public List<string> GetUserRoles(IdentityUser identityUser)
        {
            return _userManager.GetRoles(identityUser.Id).ToList();
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
