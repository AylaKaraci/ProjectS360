using ProjectS360.MODEL.Entities;
using ProjectS360.SERVICE.Option;
using ProjectS360.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectS360.UI.Areas.Member.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Member/Register
        #region Services
        AppUserService _appUserService;
        CompanyService _companyService;
        #endregion

        #region Constructor
        public RegisterController()
        {
            _appUserService = new AppUserService();
            _companyService = new CompanyService();
        }

        #endregion

        #region Methods

        [HttpGet]
        public ActionResult Register()
        {
            List<Company> companies = _companyService.GetActive().ToList();
            return View(companies);
           
        }

        [HttpPost]
        public ActionResult Register(AppUser data, HttpPostedFileBase image)
        {
            // Kayıt formunu içindeki bilgilerle gönder.
            data.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
                data.ImagePath = "~/Content/img/author/author_1.png"; //herhangi bir hatada default resim bu olacak

            data.Role = Role.Member;

            _appUserService.Add(data);

            return View();
        } 
        #endregion
    }
}