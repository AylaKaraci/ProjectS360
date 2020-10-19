using ProjectS360.MODEL.Entities;
using ProjectS360.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectS360.UI.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorize : AuthorizeAttribute
    {
        // Roller tutmak için string dizi oluşturuldu.
        private string[] UserProfileRequired { get; set; }

        #region CustomAuthorize
        public CustomAuthorize(params object[] userProfilesRequired)
        {
            if (userProfilesRequired.Any(p => p.GetType().BaseType != typeof(Enum)))
            {
                // Eğer gelen tipler Enum değilse hata fırlat!
                throw new ArgumentException("userProfilesRequired");
            }

            this.UserProfileRequired = userProfilesRequired.Select(p => Enum.GetName(p.GetType(), p)).ToArray();
        } 
        #endregion

        #region OnAuthorization
        public override void OnAuthorization(AuthorizationContext context)
        {
            bool authorized = false;
            AppUserService service = new AppUserService();

            AppUser user = service.FindByUserName(HttpContext.Current.User.Identity.Name); // Geçerli kullanıcının kullanıcı adına göre user'ı bul.

            string userRole = Enum.GetName(typeof(Role), user.Role);

            foreach (var role in this.UserProfileRequired)
            {
                if (userRole == role)
                {
                    authorized = true;
                    break;
                }
            }

            if (!authorized)
            {
                var url = new UrlHelper(context.RequestContext);
                var logonUrl = url.Action("Index", "Home", new { Id = 302, Area = "" });
                context.Result = new RedirectResult(logonUrl);

                return;
            }
        } 
        #endregion

    }
}