using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DemoCustomControllerFactory.BizLayer;

namespace MVC_DemoCustomControllerFactory.Controllers
{
    public class HomeController : Controller
    {

        private IBizLayer bizLayer = null;

        public HomeController(IBizLayer bizlayer)
        {
            this.bizLayer = bizlayer;
        }
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = bizLayer.GetData();
            return View();
        }
    }
}