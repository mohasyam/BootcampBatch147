using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class SalaryDefaultValueController : Controller
    {
        // GET: SalaryDefaultValue
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View("_List", SalaryDefaultValueRepo.Get());
        }

        public ActionResult Create()
        {
            ViewBag.JobPositionList = new SelectList(JobPositionRepo.Get(), "Id", "Description");
            ViewBag.SalaryComponentList = new SelectList(SalaryComponentRepo.Get(), "Id", "Description");
            return View("_Create");
        }

        [HttpPost]
        public ActionResult Create(SalaryDefaultValueViewModel model)
        {
            
                Responses responses = SalaryDefaultValueRepo.Update(model);
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
                }
            
            
        }

        public ActionResult Edit(int Id)
        {
            ViewBag.JobPositionList = new SelectList(JobPositionRepo.Get(), "Id", "Description");
            ViewBag.SalaryComponentList = new SelectList(SalaryComponentRepo.Get(), "Id", "Description");
            return View("_Edit", SalaryDefaultValueRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(SalaryDefaultValueViewModel model)
        {
            
                Responses responses = SalaryDefaultValueRepo.Update(model);
                if (responses.Success)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
                }
            
        }

        public ActionResult Delete(int id)
        {
            return View("_Delete", SalaryDefaultValueRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = SalaryDefaultValueRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}