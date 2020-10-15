using ProjectS360.MODEL.Entities;
using ProjectS360.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectS360.UI.Controllers
{
    public class HomeController : Controller
    {
        AppUserService _appUserService;
        public ActionResult Index()
        {
            return View();
        }
        public HomeController()
        {
            _appUserService = new AppUserService();
        }

        //public ActionResult Index(int? id)//Guid? id AutService katman işlemleri bittikten sonra buraya ekledik. bu if bloğunuda  de aynı şekilde
        //{
        //    if (id != null)
        //    {
        //        AppUser user = new AppUser();
        //        user = _appUserService.GetById((int)id);
        //        string cookie = user.UserName.ToString();
        //        FormsAuthentication.SetAuthCookie(cookie, true); // kullanıcının id si ile geri dönecek Indexe ve cookie oluşturacak. kullanıcı id yoksa cookie oluşturmayacak normal indexe geri dönecek.Cookie oluştur. İkinci parametre olarak da kalıcı olup olmadığını belirt.

        //        if (user.Role == Role.Admin)
        //        {
        //            //Kullanıcı rolü Admin ise Admin sayfasına yönlendir.
        //            return Redirect("~/Admin/Home/Index");
        //        }
        //    }

        //    var model = _productService.GetDefault(x => x.UnitsInStock > 0 && x.Status == CORE.Entity.Enum.Status.Active).OrderByDescending(x => x.CreatedDate).Take(16).ToList(); //stokta olanları ve aktif olanları çekiyoruz
        //    return View(model);
        //}



        public ActionResult Login()
        {         
            return View();
        }

        public RedirectResult Logout()
        {
            FormsAuthentication.SignOut(); //Çıkış yap
            //bunu AutService katman işlemleri bittikten sonra buraya ekledik.
            return Redirect("~/Home/Index");
        }
    }
}