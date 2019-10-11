using System.Collections.Generic;
using System.Web.Http;
using RentAVehicle.BL.DTO;
using RentAVehicle.BL.Manager;

namespace RentAVehicle.API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("brands")]
    public class BrandController : ApiController
    {
        [HttpGet]
        [Route("List")]
        public List<BrandDTO> GetBrandList()
        {
            BrandManager brand = new BrandManager();

            var brandList = brand.GetBrandList();

            return brandList;
        }
    }
}
