using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

/// <summary>
/// Summary description for CustomServiceRegistry
/// </summary>
public static class CustomServiceRegistry
{
     
        public static CustomService GetServiceRegistry(this HttpControllerDescriptor descriptor)
        {
            return CustomServiceRegistryProvider.Registry().FirstOrDefault(r => r.Name == descriptor.ControllerName);
        }

        public static CustomService GetServiceRegistry(this HttpActionDescriptor descriptor)
        {
            var name = descriptor.ControllerDescriptor.ControllerName + "." + descriptor.ActionName;

            var actionRegistry = CustomServiceRegistryProvider.Registry().FirstOrDefault(r => r.Name == name);

            return actionRegistry ?? descriptor.ControllerDescriptor.GetServiceRegistry();
        }
     
}

public class CustomService
{
    public string Name { get; set; }
    public string Status { get; set; }
    public bool Bespoke { get; set; }
    public bool Locked { get; set; }
}