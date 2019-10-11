using System;
using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("opinion")]
    [AllowAnonymous]
    public class OpinionController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public List<OpinionDTO> GetOpinionByClient(Guid clientId)
        {
            OpinionManager opinion = new OpinionManager();

            var opinionList = opinion.GetOpinionByClient(clientId);

            return opinionList;
        }
    }
}