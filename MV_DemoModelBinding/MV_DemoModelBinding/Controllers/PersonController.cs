using MV_DemoModelBinding.Binders;
using MV_DemoModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MV_DemoModelBinding.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(PersonModelBinder))]PersonModel person)
        {   //To Do : Write logic to process the model data
            return View(person);
        }


   

    }
}