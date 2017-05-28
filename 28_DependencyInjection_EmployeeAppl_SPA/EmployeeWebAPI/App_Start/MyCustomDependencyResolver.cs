using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace EmployeeWebAPI.App_Start
{
    public class MyUnityResolver:System.Web.Http.Dependencies.IDependencyResolver
    {
        protected IUnityContainer container;

        public MyUnityResolver(IUnityContainer container)
        {
            if(container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch(ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type ServiceType)
        {
            try
            {
                return container.ResolveAll(ServiceType);
            }
            catch(ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new MyUnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}