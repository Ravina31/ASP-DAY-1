using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyBizLayer;
using CompanyEntities.Models;

namespace CompanyEntities.Controllers
{
    public class DeptController : Controller
    {
        private DeptBizLayer bizLayer = null;
        // GET: Dept

            public DeptController()
        {
            bizLayer = new DeptBizLayer();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(bizLayer.GetDepts());
        }

        // GET: Dept/Details/5
        public ActionResult Details(int id)
        {
            return View(bizLayer.GetDeptByDeptNo(id));
        }

        // GET: Dept/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dept/Create
        [HttpPost]
        public ActionResult Create(DeptModel dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = bizLayer.AddDept(dept);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(dept);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
                return View(dept);
            }
        }

        // GET: Dept/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(bizLayer.GetDeptByDeptNo(id));
        }

        // POST: Dept/Edit/5
        [HttpPost]
        public ActionResult Edit(DeptModel dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = bizLayer.UpdateDept(dept);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(dept);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
                return View(dept);
            }
        }

        // GET: Dept/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(bizLayer.GetDeptByDeptNo(id));
        }

        // POST: Dept/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = bizLayer.RemoveDeptByDeptNo(id);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(bizLayer.GetDeptByDeptNo(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
                return View(bizLayer.GetDeptByDeptNo(id));
            }
        }
    }
}
