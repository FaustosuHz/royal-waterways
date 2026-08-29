using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filter
{
    public class Socio : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != "Socio")
            {
                context.Result = new RedirectToActionResult("index", null, null);
            }
            else
            {
                context.Result = new RedirectResult("/login/login");
            }
        }
    }
}
