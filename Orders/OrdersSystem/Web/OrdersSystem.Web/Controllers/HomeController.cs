using System.Web.Mvc;

namespace OrdersSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }       
    }
}