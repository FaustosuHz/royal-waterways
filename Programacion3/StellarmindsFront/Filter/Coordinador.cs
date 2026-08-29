using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filter
{
    public class Coordinador : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != "Coordinador")
            {
                context.Result = new RedirectToActionResult("index", "Home", null);
            }

        }
    }
}
