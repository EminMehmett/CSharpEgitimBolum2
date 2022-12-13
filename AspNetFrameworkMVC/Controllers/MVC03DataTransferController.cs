using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        // GET: MVC03DataTransfer
        public ActionResult Index(string txtAra)
        {
            //MVC de temel olarak 3 türde viev a veri yollama yapısı var
            //Örneğin veritabanından ürün bilgisini çekip ekrana yollamak için 

            // 1- VievBag  : Tek Kullanımlık Ömrü Var
            ViewBag.UrunKategorisi = "Bİlgisayar";
            // 2- VievData : Tek Kullanımlık Ömrü Vardır
            ViewData["UrunAdi"] = "Acer Monitör";
            // 3- TempData : 2 Kullanımlık Ömrü Vardır 
            TempData["UrunFiyati"] = 3499;

            ViewBag.GetVerisi = txtAra;

            return View();
        }
        [HttpPost] // Aşağıdaki metodun sadece post yönteminde çalışmasını sağlar 
        public ActionResult Index(string text1, string ddlListe, bool cbOnay, FormCollection formCollection)
        {
            // 1. Yöntem parametrelerden gelen veriler;

            ViewBag.Mesaj = "Textboxdan gelen veri : " + text1;
            ViewBag.MesajListe = "Liste den seçilen değer : " + ddlListe;
            TempData["Tdata"] = "Checkbox dan  seçilen değer : " + cbOnay;

            //2. Yöntem Request Form ile verileri yakalama

            ViewBag.Mesaj2 = "Textboxdan gelen veri : " + Request.Form["text1"];
            ViewBag.MesajListe2 = "Liste den seçilen değer : " + Request.Form["ddlListe"];
            TempData["Tdata2"] = "Checkbox dan  seçilen değer : " + Request.Form.GetValues("cbOnay")[0]; // checkbox verisi bu şekilde yakalanıyor

            //3. Yöntem FormCollection ile verileri yakalama 

            ViewBag.Mesaj3 = "Textboxdan gelen veri : " + formCollection["text1"];
            ViewBag.MesajListe3 = "Liste den seçilen değer : " + formCollection["ddlListe"];
            TempData["Tdata3"] = "Checkbox dan  seçilen değer : " + formCollection.GetValues("cbOnay")[0];
            return View();
        }

    }
}