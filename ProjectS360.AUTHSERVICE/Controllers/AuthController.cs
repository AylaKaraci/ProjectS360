using ProjectS360.AUTHSERVICE.Models;
using ProjectS360.MODEL.Entities;
using ProjectS360.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectS360.AUTHSERVICE.Controllers
{
    public class AuthController : ApiController
    {
        #region Service

        AppUserService _appUserSevice;

        #endregion

        //https://localhost:44335/  UI katmanı url.

        #region Constructor

        public AuthController()
        {
            _appUserSevice = new AppUserService();
        }

        #endregion

        #region HttpMethods

        [HttpPost]
        public HttpResponseMessage Login(Credentials model)
        {
            var url = "";

            if (model.username == null || model.password == null)
            {
                // Tekrar giriş sayfasına yönlendir
                url = "https://localhost:44335/Home/Login";

                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
            }

            if (_appUserSevice.CheckCredentials(model.username, model.password))
            {
                AppUser user = new AppUser();
                user = _appUserSevice.FindByUserName(model.username);

                if (user.Role == Role.Admin || user.Role == Role.Member)
                {
                    url = "https://localhost:44335/Home/Index/" + user.ID;
                    return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = url });
                }
                else
                {
                    url = "https://localhost:44335/Home/Index";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Success = true, RedirectUrl = url });
                }
            }

            url = "https://localhost:44335/Home/Login";
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
        }

        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var newUrl = "https://localhost:44335/Home/Logout";
            return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = newUrl });
        }

        #endregion
    }
}
