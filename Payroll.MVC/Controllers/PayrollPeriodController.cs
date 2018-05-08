using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class PayrollPeriodController : Controller
    {
        // GET: PayrollPeriod
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectPeriod()
        {
            return PartialView("_SelectPeriod", PayrollPeriodRepo.Get());
        }

        [HttpPost]
        public ActionResult SelectedPeriod(int id)
        {
            if (PayrollPeriodRepo.SelectPeriod(id))
            {
                return Json(new { success = true, description = PayrollPeriodRepo.SelectedPeriod.Description }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, description = PayrollPeriodRepo.SelectedPeriod.Description }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult List()
        {
            return View("_List", PayrollPeriodRepo.Get());
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(PayrollPeriodViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = PayrollPeriodRepo.Update(model);
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
            return View("_Edit", PayrollPeriodRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(PayrollPeriodViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = PayrollPeriodRepo.Update(model);
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

        public ActionResult Delete(int Id)
        {
            return View("_Delete", PayrollPeriodRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = PayrollPeriodRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}