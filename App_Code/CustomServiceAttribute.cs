using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

/// <summary>
/// Summary description for CustomServiceAttribute
/// </summary>
public class CustomServiceAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        var actionServiceRegistry = actionContext.ActionDescriptor.GetServiceRegistry();
        var controllerServiceRegistry = actionContext.ActionDescriptor.ControllerDescriptor.GetServiceRegistry();

        if (actionServiceRegistry == null && controllerServiceRegistry == null)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound);
            return;
        }

        var modelState = actionContext.ModelState;
        if (!modelState.IsValid)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, modelState);

        }



        if ((actionServiceRegistry != null && actionServiceRegistry.Locked) || (controllerServiceRegistry != null && controllerServiceRegistry.Locked))
        {
            //TODO: Replace with actual sample?
            var sample = "I'm a sample";
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, sample);
            return;
        }
    }
}