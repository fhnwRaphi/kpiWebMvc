using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace kpiMvcApi
{   
    /// <summary>
    /// Configuratuion für die Website
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Setup der Routen
        /// id als optionalen wert Bsp. id? int =1
        /// Registrieren der Startup View "Frame" 
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Frame", id = UrlParameter.Optional }
            );
        }
    }
}
