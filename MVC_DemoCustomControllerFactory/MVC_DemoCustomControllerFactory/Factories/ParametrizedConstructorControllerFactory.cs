using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using MVC_DemoCustomControllerFactory.Controllers;
using MVC_DemoCustomControllerFactory.BizLayer;
using System.Reflection;
using System.Configuration;

namespace MVC_DemoCustomControllerFactory.Factories
{
    public class ParametrizedConstructorControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            //DI
            //IController controller = new HomeController(new BizLayer1());
            //return controller;

            //DI using reflection
            Assembly asm = Assembly.GetExecutingAssembly();
            if (controllerName == "Home")
            {
                string currentBizLayer = ConfigurationManager.AppSettings["currentBizLayer"];
                Type BizLayerType = asm.GetTypes().SingleOrDefault(t => t.FullName == currentBizLayer); //Getting type of Bizlayer to be instantiated.
                IBizLayer bizlayer = Activator.CreateInstance(BizLayerType) as IBizLayer; //instantiating the bizlayer class.
                Type ControllerType = asm.GetTypes().SingleOrDefault(t => t.Name == controllerName + "Controller"); //Getting type of Bizlayer to be instantiated.
                IController controller = Activator.CreateInstance(ControllerType, bizlayer) as IController;
                return controller;
            }
            else
            {
                Type ControllerType = asm.GetTypes().SingleOrDefault(t => t.Name == controllerName + "Controller"); //Getting type of Bizlayer to be instantiated.
                IController controller = Activator.CreateInstance(ControllerType) as IController;
                return controller;
            }
           
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            controller = null;
            GC.Collect();
        }
    }
}