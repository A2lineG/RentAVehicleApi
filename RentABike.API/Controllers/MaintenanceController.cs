using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Maintenance")]
    [Authorize(Roles = "admin")]
    public class MaintenanceController : ApiController
    {
        private MaintenanceManager _manager;

        public MaintenanceController()
        {
            _manager = new MaintenanceManager();
        }

        [HttpGet]
        [Route("List")]
        public List<MaintenanceDTO> GetMaintenanceList(DateTime startDate, DateTime endDate)
        {
            var maintenanceList = _manager.GetMaintenanceByDate(startDate, endDate);

            return maintenanceList;
        }
        
        [HttpPost]
        [Route("Add")]
        public MaintenanceDTO AddMaintenance(MaintenanceDTO maintenanceDto)
        {
            return _manager.CreateMaintenance(maintenanceDto);
        }

        [HttpPost]
        [Route("Update")]
        public MaintenanceDTO UpdateMaintenance(MaintenanceDTO maintenanceDto)
        {
            return _manager.UpdateMaintenance(maintenanceDto);
        }

        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage DeleteMaintenance(Guid maintenanceId)
        {
            _manager.DeleteMaintenance(maintenanceId);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
