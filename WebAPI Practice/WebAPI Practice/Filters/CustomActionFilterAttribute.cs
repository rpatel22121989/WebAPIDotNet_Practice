using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI_Practice.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // This method is called before the action method is executed.
            Console.WriteLine("Action method is executing");

            // You can access request details from the actionContext
            var request = actionContext.Request;

            // You can perform any custom logic here

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // This method is called after the action method is executed.
            Console.WriteLine("Action is executed.");

            // You can access response details from the actionExecutedContext
            var response = actionExecutedContext.Response;

            // You can perform any custom logic here

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}