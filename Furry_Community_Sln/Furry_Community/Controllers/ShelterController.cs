using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Furry_Community.Models.DataBase;
namespace Furry_Community.Controllers
{
    public class ShelterController : Controller
    {
        // GET: Shelter
        public ActionResult Index()
        {
            return View();
        }

        Furry_DB db = new Furry_DB();
        public ActionResult AllShelters_Page()
        {
            var zapros = from table in db.id_shelter
                         select table;
            IEnumerable<id_shelter> shelter = zapros;
            ViewData["spisokShelters"] = shelter;

            return View();
        }


       


    }

  
}