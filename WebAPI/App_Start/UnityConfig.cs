using Microsoft.Practices.Unity;
using System.Web.Http;
using Implementation;
using Unity.WebApi;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            //Goes to register implementation

            TypeRegisteration.RegisterType(container);
            
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}