using ProjectS360.MODEL.Entities;
using ProjectS360.SERVICE.Option;
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
    public class CompanyController : Controller
    {
        // GET: Admin/Company

        #region Services
        CompanyService _companyService;
       
        #endregion

        #region Constructor
        public CompanyController()
        {
            _companyService = new CompanyService();
            
        }
        #endregion

        #region Actions
        public ActionResult List()
        {
            List<Company> companies = _companyService.GetActive().ToList();

            return View(companies);
        }

        [HttpGet]
        public ActionResult Add() => View();

        [HttpPost]
        public RedirectResult Add(Company data, HttpPostedFileBase image)
        {
            // Üye Ekleme formunu içindeki bilgilerle gönderir.
            data.Logo = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.Logo == "0" || data.Logo == "1" || data.Logo == "2")
                data.Logo = "~/Content/img/company/logo1.png"; // Image yüklenmezse bu görsel yüklenecek.

            _companyService.Add(data);

            return Redirect("/Admin/Company/List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {      
            Company model = _companyService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Company data, HttpPostedFileBase image)
        {
            // Üye Ekleme formunu içindeki bilgilerle gönderir.
            data.Logo = ImageUploader.UploadSingleImage("~/Uploads/", image);

            if (data.Logo == "0" || data.Logo == "1" || data.Logo == "2")
            {
                Company updated = _companyService.GetById(data.ID);

                if (updated.Logo == null || updated.Logo == "~/Content/img/company/logo1.png")
                    data.Logo = "~/Content/img/company/logo1.png"; // Image yüklenmezse bu görsel yüklenecek.
                else
                    data.Logo = updated.Logo;
            }

            _companyService.Update(data);

            return Redirect("/Admin/Company/List");//Admin deki AppUserControllerımdaki List metoduna(actionına) redirekt olacak.
        }

        public RedirectResult Delete(int id)
        {
            _companyService.Remove(id);//gelen id yi alacak ve Remove metodu bu id yi silecek.
            return Redirect("/Admin/Company/List");
        }

        #endregion
    }
}