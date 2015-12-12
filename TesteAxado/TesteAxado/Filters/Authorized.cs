using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace TesteAxado.Filters
{
    public class AuthorizedAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!Commom.TesteAxadoSession.IsAuthenticated)
            {
                return false;
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {            
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Home",
                        action = "Index"
                    })
                );
        }
    }
}