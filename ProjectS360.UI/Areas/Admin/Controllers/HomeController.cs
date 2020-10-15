using ProjectS360.MODEL.Entities;
using ProjectS360.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectS360.UI.Areas.Admin.Controllers
{
    
    public class HomeController : Controller
    {
        // GET: Admin/Home

        #region Services
        AppUserService _appUserService;
        CompanyService _companyService; 
        #endregion

        #region Constructor
        public HomeController()
        {
            _appUserService = new AppUserService();
            _companyService = new CompanyService();
        }
        #endregion

        #region Actions
        public ActionResult Index()
        {
            List<AppUser> appUsers = _appUserService.GetActive().ToList();
            List<Company> companies = _companyService.GetActive().ToList();

            ViewBag.User = appUsers.Count;
            ViewBag.Company = companies.Count;

            return View();
        } 
        #endregion
    }
}