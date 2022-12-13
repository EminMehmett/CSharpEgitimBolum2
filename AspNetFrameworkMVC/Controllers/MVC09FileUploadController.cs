using System.IO; // dosya işlemnleri için gerekli kütüphane
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC09FileUploadController : Controller
    {
        // GET: MVC09FileUpload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase dosya) // Ön yüzde file upload elementine name olarak ne isim verdiysek onu kullanmalıyız
        {
            if (dosya != null && dosya.ContentLength > 0) // dosya gönderilmişse 
            {
                var uzanti = Path.GetExtension(dosya.FileName); // Dosya uzantı kontrolü yapmak istersek 
                if (uzanti == ".jpg" || uzanti == ".jpeg" || uzanti == ".png" || uzanti == ".gif") // Sadece bu uzantılardaki dosyaları kabul et
                {
                    // 1. Yöntem : Random(Rastgele) İsimli Dosya Yükleme 
                    var klasör = Server.MapPath("/Images"); // Resmi yükleyeceğimi klasör(Eğer projede bu klasör yoksa oluşturmalıyız yoksa hata veriri!)
                    var randomFileName = Path.GetRandomFileName(); // Rastgele dosya ismi oluşturma metodu
                    var fileName = Path.ChangeExtension(randomFileName, ".jpg"); // dosya adını ve uzantısını değiştirip birleştirdik 
                    var path = Path.Combine(klasör, fileName); // klasör ve resim adını birleştirdik 
                    //dosya.SaveAs(path); // Resmi farklı kaydet metoduyla sunucuya yüklüyoruz.
                    //ViewBag.ResimAdi = fileName;

                    //  2. Yöntem : Resmi Kendi Adıyla Yükleme 
                    var dosyaAdi = Path.GetFileName(dosya.FileName);
                    var yol = Path.Combine(klasör, dosyaAdi);

                    //dosya.SaveAs(yol);

                    // 3. Yöntem : Resmi Direkt Sunucuya Yollamak  
                    dosya.SaveAs(Server.MapPath("/Images/" + dosya.FileName));

                    ViewBag.ResimAdi = dosya.FileName;
                }
            }
            else ViewData["mesage"] = "Sadece .jpg, .jpeg, .png, .gif Resimleri Yükleyebilirsiniz!";
            return View();
        }
    }
}