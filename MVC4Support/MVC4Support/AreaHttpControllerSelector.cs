using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dispatcher;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Reflection;
using Common.Logging;
using Spring.Context;
using Spring.Context.Support;

namespace MVC4Support
{
    public class AreaHttpControllerSelector : DefaultHttpControllerSelector
    {
        private static ILog Logger = LogManager.GetLogger<AreaHttpControllerSelector>();

        private readonly HttpConfiguration _configuration;

        private const string ControllerSuffix = "Controller";
        private const string AreaRouteVariableName = "area";

        public AreaHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            _configuration = configuration;
        }

        private Dictionary<string, Type> _apiControllerTypes;

        private Dictionary<string, Type> ApiControllerTypes
        {
            get { return _apiControllerTypes ?? (_apiControllerTypes = GetControllerTypes()); }
        }

        /// <summary>
        /// Method GetControllerTypes takes all the API controllers types from all of your assemblies, 
        /// and store it inside the dictionary, where the key is FullName of the type and value is the type itself.
        /// Of course we will set this dictionary only once. And then just use it.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, Type> GetControllerTypes()
        {

            

            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            //foreach (Assembly asm in assemblies)
            //{
            //    Type[] ts = asm.GetTypes();
            //    foreach (Type t in ts)
            //    {
            //        Logger.Debug(" Type Full Name = " + t.FullName);
            //    }
            //}

            //var types = assemblies.SelectMany(a => a.GetTypes().Where(t => !t.IsAbstract && t.Name.EndsWith(ControllerSuffix) && typeof(IHttpController).IsAssignableFrom(t)))
            //    .ToDictionary(t => t.FullName, t => t);

            IApplicationContext context = ContextRegistry.GetContext();

            IDictionary<string, IHttpController> controllers = context.GetObjects<IHttpController>();


            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Dictionary<string, Type> types = new Dictionary<string, Type>();
            if (controllers != null)
            {
                foreach (var bean in controllers)
                {
                    types.Add(bean.Value.GetType().FullName, bean.Value.GetType());
                }
            }
            
            return types;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            //return GetApiController(request) ?? base.SelectController(request);

            return GetApiController(request);
        }


        private static string GetAreaName(HttpRequestMessage request)
        {
            var data = request.GetRouteData();

            if (!data.Values.ContainsKey(AreaRouteVariableName))
            {
                return null;
            }

            return data.Values[AreaRouteVariableName].ToString().ToLower();
        }

        private Type GetControllerTypeByArea(string areaName, string controllerName)
        {
            var areaNameToFind = string.Format(".{0}.", areaName.ToLower());
            var controllerNameToFind = string.Format(".{0}{1}", controllerName, ControllerSuffix);

            return ApiControllerTypes.Where(t => t.Key.ToLower().Contains(areaNameToFind) && t.Key.EndsWith(controllerNameToFind, StringComparison.OrdinalIgnoreCase))
                    .Select(t => t.Value).FirstOrDefault();
        }

        private HttpControllerDescriptor GetApiController(HttpRequestMessage request)
        {
            var controllerName = base.GetControllerName(request);

            var areaName = GetAreaName(request);
            if (string.IsNullOrEmpty(areaName))
            {
                return null;
            }

            var type = GetControllerTypeByArea(areaName, controllerName);
            if (type == null)
            {
                return null;
            }

            return new HttpControllerDescriptor(_configuration, controllerName, type);
        }
    }
}
