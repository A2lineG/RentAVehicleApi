using System;
using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("OptionBooking")]
    [AllowAnonymous]
    public class OptionBookingController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public List<OptionBookingDTO> GetOptionBookingList()
        {
            OptionBookingManager optionBookingManager =  new OptionBookingManager();

            var optionBooking = optionBookingManager.GetOptionBookingList();

            return optionBooking;
        }
    }
}