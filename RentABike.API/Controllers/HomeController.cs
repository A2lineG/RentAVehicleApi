using System.Web.Mvc;

namespace RentAVehicle.API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
