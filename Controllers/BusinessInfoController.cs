using AspNetMVCRazor.Models.BusinessInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCRazor.Controllers
{
    public class BusinessInfoController : Controller
    {
        // Only in .Net Core which has Singleton object
        //public BusinessInfoController() { }
        //public BusinessInfoController(IBusinessInfoMemory service)
        //{
        //    this.service = service;
        //}

        private IBusinessInfo service = new BusinessInfoService();
        private BusinessInfoDBContext db = new BusinessInfoDBContext();

        // GET: BusinessInfo
        public ActionResult Index()
        {
            //return View(service.GetAll());
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult AddressList()
        {
            
            return PartialView("_AddressList", service.GetAllAddresses());
        }

        [ChildActionOnly]
        public ActionResult BusinessInfoList()
        {
            var bizList = service.GetAllBusinessInfo();
            return PartialView("_BusinessInfoList", bizList);
        }

        // return a String instead of ActionResult
        public String IndexString()
        {
            return "This is Index action method of BusinessInfoController";
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var biz = service.GetById(id);
            return View(biz);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            //var biz = service.GetById(id);

            //db.BusinessInfo.Remove(biz);
            //db.BusinessInfo.Add(biz);

            //return View("Index");

            try
            {
                var biz = db.BusinessInfo.Single(record => record.BusinessInfoId == id); //db.Employees.Single(m => m.ID == id);

                if (TryUpdateModel(biz))
                {
                    db.SaveChanges();

                    //int.TryParse(Request.Form["BusinessInfoId"], out biz.BusinessInfoId);
                    biz.BusinessInfoName = Request.Form["BusinessInfoName"];
                    return RedirectToAction("Index");
                }
                return View(biz);
            }
            catch
            {
                return View();
            }
        }
    }
}