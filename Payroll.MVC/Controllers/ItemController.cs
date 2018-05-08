using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll.MVC.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View("_List", ItemRepo.Get());
        }

        public ActionResult Create()
        {
            return View("_Create");
        }

        [HttpPost]
        public ActionResult Create(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = ItemRepo.Update(model);
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
            return View("_Edit", ItemRepo.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                Responses responses = ItemRepo.Update(model);
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
            return View("_Delete", ItemRepo.GetById(id));
        }

        //POST DELETE
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            Responses responses = ItemRepo.Delete(id);
            if (responses.Success)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
        }
    }
}