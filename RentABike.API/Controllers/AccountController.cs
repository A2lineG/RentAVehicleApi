using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiController
    {
        private AuthManager _authenticationManager = null;

        public AccountController()
        {
            _authenticationManager = new AuthManager();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(AuthDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _authenticationManager.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Authorize]
        [Route("Info")]
        public async Task<UserLoginDTO> GetUserInfo()
        {
            var userLogin = new UserLoginDTO() {UserName = User.Identity.Name};

            var userIdentity = await _authenticationManager.GetUserByName(userLogin.UserName);

            userLogin.Email = userIdentity.UserName;

            var clientManager = new ClientManager();

            var client = clientManager.GetClientByMail(userLogin.Email);
            if (client != null)
            {
                userLogin.Id = client.Id;
                userLogin.FullName = $"{client.FirstName} {client.Surname}";
            }
            
            userLogin.Roles = _authenticationManager.GetUserRoles(userIdentity);

            return userLogin;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authenticationManager.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
