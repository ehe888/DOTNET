using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using WebAPISample.Models;

namespace WebAPISample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{area}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Role>("Roles");
        }
    }
}
