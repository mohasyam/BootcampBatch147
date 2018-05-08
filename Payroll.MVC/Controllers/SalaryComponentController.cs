using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class SalaryComponentController : Controller
    {
        // GET: SalaryComponent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View("_List", SalaryComponentRepo.Get());
        }

        public ActionResult Create()
        {
            return View("_Create", new SalaryComponentViewModel());
        }

        [HttpPost]
        public ActionResult Create(SalaryComponentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = SalaryComponentRepo.Update(model);
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
            return View("_Edit", SalaryComponentRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(SalaryComponentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = SalaryComponentRepo.Update(model);
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
            return View("_Delete", SalaryComponentRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = SalaryComponentRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}