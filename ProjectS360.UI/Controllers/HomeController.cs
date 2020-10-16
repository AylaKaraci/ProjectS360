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
        #region Services

        AppUserService _appUserService;

        #endregion

        #region Constructor
        public HomeController()
        {
            _appUserService = new AppUserService();
        }
        #endregion

        #region Methods
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                AppUser user = new AppUser();
                user = _appUserService.GetById((int)id);
                string cookie = user.UserName.ToString();
                FormsAuthentication.SetAuthCookie(cookie, true);

                if (user.Role == Role.Admin)
                {

                    return Redirect("~/Admin/Home/Index");
                }
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public RedirectResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/Home/Index");
        } 
        #endregion
    }
}