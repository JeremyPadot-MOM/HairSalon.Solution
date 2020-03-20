using Microsoft.AspNetCore.Mvc;

namespace HariSalon.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}