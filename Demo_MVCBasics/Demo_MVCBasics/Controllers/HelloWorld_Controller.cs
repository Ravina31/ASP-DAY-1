using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_MVCBasics.Models;
using System.Diagnostics;

namespace Demo_MVCBasics.Controllers
{
    public class HelloWorld_Controller : Controller
    {  // [HttpGet]
        // GET: HelloWorld_
        //public string Hello()
        //{
        //    return "<h1 style='color:blue;'>Hello World</h1>";
        //}


        //[HttpGet]
        //public ContentResult Hello()
        //{
        //    return Content("<h1 style='color:blue;'>Hello World</h1>");
        //}


        [HttpGet]
        public ViewResult Hello()
        {
            //ViewData.Add("data1", " Hello World (From controller using ViewData)!");
            //ViewBag.data2 = "Hello World (From controller using ViewBag)!";
            HelloModel model = new HelloModel() { Data = "Hello World (From controller using Model)!" };
            //ViewData.Model = model;
            return View(model);
        }

        [HttpPost]
        public ViewResult Hello(HelloModel model)
        { 
            Debug.WriteLine(model.Data);
            return View(model);
        }
    }
}