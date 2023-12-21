using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Proyecto_Cliente.Helpers
{
    public class LogApiRequestAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// For Web API controllers
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var request = actionExecutedContext.Request;
            var response = actionExecutedContext.Response;
            var actionContext = actionExecutedContext.ActionContext;

        }

    }
}
