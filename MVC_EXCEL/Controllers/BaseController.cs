using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EXCEL.Models;
using System.Data;

namespace MVC_EXCEL.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

        /// <summary>  
        /// First Action method called when page loads  
        /// Fetch all the rows from DB and display it  
        /// </summary>  
        /// <returns>Home View</returns>  
        public ActionResult Index()
        {
            List<TableModel> model = new List<TableModel>();
            model = BusinessLogic.ExcellBusinessLogic.GetAllRecords();
            return View("Index", model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNewPage(string PageName)
        {
            return Json(BusinessLogic.ExcellBusinessLogic.GetNewPage(PageName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FinderPage(FormCollection form)
        {
            List<TableModel> models = new List<TableModel>();
            models = BusinessLogic.ExcellBusinessLogic.GetSearched(form["searchtext"]);
            TempData["searched"] = form["searchtext"];
            return View(models);
        }

        [ChildActionOnly]
        public ActionResult GetHtmlPage(string path)
        {
            return new FilePathResult("~/Content/one.html", "text/html");
        }
    }
}