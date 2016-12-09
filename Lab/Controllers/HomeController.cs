using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LINQtoCSV;
using Lab.Models;

namespace Lab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]

        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/ App_Data /"), fileName);

                file.SaveAs(path);

                TempData["file"] = path;

            }

            return RedirectToAction("Grid");

        }

        public ActionResult Grid()
        {
            string file = TempData["file"] as string;
            if (file == null)
            {
                return RedirectToAction("Index");
            }

            CsvContext cc = new CsvContext();
            List<Number> digits = cc.Read<Number>(file).ToList();

            return View(digits);

        }
    }
}