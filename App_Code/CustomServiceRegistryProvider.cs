using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomCustomCustomService Provider
/// </summary>
public class CustomServiceRegistryProvider
{ 
    //public static string CustomServiceSectionName { get; set; }
    //public static string ClientCustomServiceSectionName { get; set; }
    //public static string EnvironmentSectionName { get; set; }

    static CustomServiceRegistryProvider()
    {
        //CustomServiceSectionName = "CustomService ";
        //ClientCustomServiceSectionName = "clientCustomService ";
        //EnvironmentSectionName = "environment";
    }

    private static IEnumerable<CustomService> _registry;

    public static IEnumerable<CustomService> Registry()
    {
        if (_registry != null) return _registry;

        IEnumerable<CustomService> staticRegistry = new[]{
            new CustomService {Name="Home" }
        };
        //var CustomService Config = (CustomService ConfigurationSection)ConfigurationManager.GetSection(CustomService SectionName);
        //var clientCustomService Config = (CustomService ConfigurationSection)ConfigurationManager.GetSection(ClientCustomService SectionName);

        //var environmentconfig = (EnvironmentConfigurationSection)ConfigurationManager.GetSection(EnvironmentSectionName);

        //var clientRegistries = clientCustomServiceConfig.Registry.OfType<CustomService Element>();
        //var serviceRegistries = CustomServiceConfig.Registry.OfType<CustomService Element>();

        _registry = staticRegistry; 
          //Union(serviceRegistries, new CustomServiceElementComparer()).
          //Select(r => new CustomService
          //{
          //    Name = r.Name,
          //    Bespoke = r.Bespoke,
          //    Locked = r.Locked,
          //    Status = r.Status
          //}).
          //Where(r => r.Status >= environmentconfig.Status).
          //ToArray();

        return _registry;
    }
}
 