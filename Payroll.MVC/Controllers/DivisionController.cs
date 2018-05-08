using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class DivisionController : Controller
    {
        // GET: Division
        public ActionResult Index()
        {
            return View(DivisionRepo.Get());
        }

        public ActionResult List()
        {
            return View("_List", DivisionRepo.Get());
        }

        public ActionResult Create()
        {
            return View("_Create");
        }

        [HttpPost]
        public ActionResult Create(DivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = DivisionRepo.Update(model);
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
            return View("_Edit", DivisionRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(DivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = DivisionRepo.Update(model);
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
            return View("_Delete", DivisionRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = DivisionRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = ModelState.ToString() }, JsonRequestBehavior.AllowGet);
        }
    }
}