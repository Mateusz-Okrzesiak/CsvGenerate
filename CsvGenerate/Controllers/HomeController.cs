using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsvGenerate.Models;
using CsvGenerate.CustomAction;

namespace CsvGenerate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult Home(Person model)
        {
            Person.PersonList.Add(model);
            return PartialView("_NameList", model);
        }

        [HttpPost]
        public ActionResult GetCSV()
        {
            return new CsvResult(Person.PersonList);
        }
    }
}