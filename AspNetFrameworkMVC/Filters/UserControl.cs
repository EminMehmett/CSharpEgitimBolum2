using System.Web.Mvc; // Filter Kullanım Kütüphanesi

namespace AspNetFrameworkMVC.Filters
{
    public class UserControl : ActionFilterAttribute // UserControl sınıfını tıpkı httppost gibi action metotlarının üzerinde attribute olarak kullanabilmemizi sağlar.
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) // OnActionExecuting metodu uygulamadaki action ların çalışması sırasında devreye girer
        {
            var UserGuidSession = filterContext.HttpContext.Session["deger"]; // uygulama içerisinde deger isminde bir session var mı

            if (UserGuidSession == null) // eğer deger isminde bir session yoksa 
                filterContext.Result = new RedirectResult("/MVC11Session?msg=AccesDenied"); // Actiona gelen isteği yakala ve kullanıcıyı /MVC11Session?msg=AccesDenied sayfasına yönlendir

            if (filterContext.HttpContext.Request.Cookies["username"] == null)
                filterContext.Result = new RedirectResult("/MVC10Cookie/CookieOlustur?msg=AccesDenied");

            base.OnActionExecuting(filterContext);
        }
    }
}