using MV_DemoModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MV_DemoModelBinding.Binders
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            PersonModel model = new PersonModel()
            {
                Id = int.Parse(request.Form["txtId"]),
                FirstName = request.Form["txtFirstName"],
                MiddleName = request.Form["txtMiddleName"],
                LastName = request.Form["txtLastName"]
            };
            //bindingContext.Model = model; setting model to let user read it from binding context object
            return model; //let user read model through function call.
        }
    }
}