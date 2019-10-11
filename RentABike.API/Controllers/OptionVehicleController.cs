using System;
using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("OptionVehicle")]
    [AllowAnonymous]
    public class OptionVehicleController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public List<OptionVehicleDTO> GetOptionVehicleList()
        {
            OptionVehicleManager optionVehicleManager = new OptionVehicleManager();

            var optionVehicle = optionVehicleManager.GetOptionVehicleList();

            return optionVehicle;
        }
    }
}