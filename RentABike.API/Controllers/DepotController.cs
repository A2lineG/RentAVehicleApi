using System;
using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [RoutePrefix("Depot")]
    [Authorize(Roles = "admin")]
    public class DepotController : ApiController
    {   
        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        [AllowAnonymous]
        public List<DepotDTO> GetDepotList()
        {
            DepotManager depotManager = new DepotManager();

            var depot = depotManager.GetDepotList();

            return depot;
        }
        /// <summary>
        /// INSERT
        /// </summary>
        /// <param name="AddDto"></param>
        [HttpPost]
        [Route("Add")]
        public void AddDepot(DepotDTO depotDto)
        {
            DepotManager depotManager = new DepotManager();

            depotManager.InsertDepot(depotDto);
        }

        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="depotDto"></param>
        [HttpPut]
        [Route("Update")]
        public void UpDateDepot(DepotDTO depotDto)
        {
            DepotManager depotManager = new DepotManager();

            depotManager.UpdateDepot(depotDto);
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("Delete")]
        public void DeleteDepot(Guid id)
        {
            DepotManager depotManager= new DepotManager();

            depotManager.DeleteDepot(id);
        }

    }
}