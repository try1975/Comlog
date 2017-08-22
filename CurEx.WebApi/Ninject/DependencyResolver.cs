using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;

namespace CurEx.WebApi.Ninject
{
    public sealed class DependencyResolver : IDependencyResolver
    {
        private readonly IKernel _container;
        public DependencyResolver(IKernel container)
        {
            _container = container;
        }
        public IKernel Container
        {
            get { return _container; }
        }
        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}