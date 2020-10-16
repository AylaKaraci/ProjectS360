using ProjectS360.MODEL.Entities;
using ProjectS360.SERVICE.Option;
using ProjectS360.UI.Areas.Admin.Data;
using ProjectS360.UI.Attributes;
using ProjectS360.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectS360.UI.Areas.Admin.Controllers
{
    [CustomAuthorize(Role.Admin)]
    public class AppUserController : Controller
    {
        // GET: Admin/AppUser
        #region Services

        AppUserService _appUserService;
        CompanyService _companyService;
      

        #endregion

        #region Constructor
        public AppUserController()
        {
            _appUserService = new AppUserService();
            _companyService = new CompanyService();
        
        }
        #endregion


        #region Actions
        public ActionResult List()
        {
            List<AppUser> appUsers = _appUserService.GetActive().ToList();
            return View(appUsers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<Company> companies = _companyService.GetActive().ToList();
            return View(companies);
        }

        [HttpPost]
        public RedirectResult Add(AppUser data, HttpPostedFileBase image)
        {
            
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
                data.ImagePath = "~/Content/img/user/user.png"; // Image yüklenmezse bu görsel yüklenecek.

            _appUserService.Add(data);

            return Redirect("/Admin/AppUser/List");
        }

        //[HttpGet]
        //public ActionResult Update(int id)
        //{           
        //    AppUser model = _appUserService.GetById(id);
        //    return View(model);
        //}
        [HttpGet]
        public ActionResult Update(int id)
        {
            AppUserVM model = new AppUserVM();
            model.AppUser = _appUserService.GetById(id);
            model.Companies = _companyService.GetActive();

            return View(model);

        }

        [HttpPost]
        public ActionResult Update(AppUser data, HttpPostedFileBase image)
        {
            // Üye Ekleme formunu içindeki bilgilerle gönderir.
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                AppUser updated = _appUserService.GetById(data.ID);

                if (updated.ImagePath == null || updated.ImagePath == "~/Content/img/user/user.png")
                    data.ImagePath = "~/Content/img/user/user.png"; // Image yüklenmezse bu görsel yüklenecek.
                else
                    data.ImagePath = updated.ImagePath;
            }

            _appUserService.Update(data);

            return Redirect("/Admin/AppUser/List");//Admin deki AppUserControllerımdaki List metoduna(actionına) redirekt olacak.
        }

        public RedirectResult Delete(int id)
        {
            _appUserService.Remove(id);//gelen id yi alacak ve Remove metodu bu id yi silecek.
            return Redirect("/Admin/AppUser/List");
        }
        #endregion
    }
}