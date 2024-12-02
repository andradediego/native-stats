using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace NativeStats.Middleware
{
    public class MobileOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

            if (!userAgent.Contains("Mobi")) // Verifica se não é dispositivo móvel
            {
                context.Result = new RedirectToActionResult("NotMobile", "Home", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
