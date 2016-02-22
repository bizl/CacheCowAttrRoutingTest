using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

/// <summary>
/// Summary description for CustomServicesRouteProvider
/// </summary>
public class CustomServicesRouteProvider:  DefaultDirectRouteProvider
{
    public override IReadOnlyList<RouteEntry> GetDirectRoutes(HttpControllerDescriptor controllerDescriptor, IReadOnlyList<HttpActionDescriptor> actionDescriptors, IInlineConstraintResolver constraintResolver)
    {
        var filter = controllerDescriptor.GetCustomAttributes<CustomServiceAttribute>().FirstOrDefault();

        if (filter == null)
        {
            return base.GetDirectRoutes(controllerDescriptor, actionDescriptors, constraintResolver);
        }

        var serviceRegistry = controllerDescriptor.GetServiceRegistry();
        if (serviceRegistry == null)
        {
            return new List<RouteEntry>();
        }
        var routes = base.GetDirectRoutes(controllerDescriptor, actionDescriptors, constraintResolver);
        return routes;
    }
}