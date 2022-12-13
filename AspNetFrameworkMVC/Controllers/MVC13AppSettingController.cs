using System.Web.Configuration; // web config den veri çekme kütüphanesi 
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC13AppSettingController : Controller
    {
        // GET: MVC13AppSetting : web.config dosyasından veri okumak için kullanılır 
        public ActionResult Index()
        {
            ViewBag.Usr = WebConfigurationManager.AppSettings["EmailUserName"];
            ViewBag.Pwd = WebConfigurationManager.AppSettings["EmailPassword"];
            return View();
        }
    }
}