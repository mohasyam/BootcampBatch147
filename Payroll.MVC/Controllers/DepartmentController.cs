using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View("_List", DepartmentRepo.Get());
        }

        public ActionResult Create()
        {
            ViewBag.DivisionList = new SelectList(DivisionRepo.Get(), "Id", "Description");
            return View("_Create");
        }

        [HttpPost]
        public ActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = DepartmentRepo.Update(model);
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = ModelState.ToString() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int Id)
        {
            return View("_Edit", DepartmentRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = DepartmentRepo.Update(model);
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { success = false, message = ModelState.ToString() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            return View("_Delete", DepartmentRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = DepartmentRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = "Error Msg" }, JsonRequestBehavior.AllowGet);
        }
    }
}