using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        // GET: EmployeeSalary
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View("_List", EmployeeSalaryRepo.Get());
        }

        public ActionResult Create()
        {
            ViewBag.PayrollPeriodList = new SelectList(PayrollPeriodRepo.Get(), "Id", "PeriodYear", "PeriodMonth");
            ViewBag.SalaryComponentList = new SelectList(SalaryComponentRepo.Get(), "Id", "Description");
            return View("_Create");
        }

        [HttpPost]
        public ActionResult Create(EmployeeSalaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = EmployeeSalaryRepo.Update(model);
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
            ViewBag.PayrollPeriodList = new SelectList(PayrollPeriodRepo.Get(), "Id", "PeriodYear", "PeriodMonth");
            ViewBag.SalaryComponentList = new SelectList(SalaryComponentRepo.Get(), "Id", "Description");
            return View("_Edit", EmployeeSalaryRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(EmployeeSalaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = EmployeeSalaryRepo.Update(model);
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
            return View("_Delete", EmployeeSalaryRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = EmployeeSalaryRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}