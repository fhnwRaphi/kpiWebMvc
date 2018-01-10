using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace kpiMvcApi
{
    /// <summary>
    /// Konfiguration für die WebApi
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Setups der API Adressen
        /// Id als Optionalen wert bsp. int? id = 1
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
