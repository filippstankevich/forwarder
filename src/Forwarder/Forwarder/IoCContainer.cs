using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ForwarderDAL.Repositories;

namespace Forwarder
{
    public class IoCContainer : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public IoCContainer()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IForwarderRepository>().To<ForwarderRepository>();
        }
    }
}