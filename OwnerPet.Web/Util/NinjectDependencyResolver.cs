using System.Web.Mvc;
using Ninject;
using System.Collections.Generic;
using System;
using OwnerPet.Service;
using OwnerPet.Service.Interfaces;

namespace OwnerPet.Web.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IPetService>().To<PetService>();
            _kernel.Bind<IUserService>().To<UserService>();
        }
    }
}