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
        //singleton
        //private static IoCContainer instance;

        private IKernel ninjectKernel;

        public IoCContainer()
        {

            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        //public static IoCContainer GetInstance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new IoCContainer();
        //    }

        //    return instance;
        //}

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

        //public IForwarderRepository GetForwarderRepository()
        //{
        //    return ninjectKernel.Get<IForwarderRepository>();
        //}

        ////static method for GetForwarderRepository. To simplify  access
        //public static IForwarderRepository GetRepository()
        //{
        //    if (instance == null)
        //    {
        //        throw new ArgumentException("Instance is not initialized");
        //    }

        //    return instance.GetForwarderRepository();
        //}
    }
}