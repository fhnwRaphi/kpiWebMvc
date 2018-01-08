using kpiMvcApi.DataTransferObjects;
using kpiMvcApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kpiMvcApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            DiagramdataDtoRepo testdata = new DiagramdataDtoRepo();
            testdata.genRandomisedData(10);
            ViewBag.diagramData = testdata;
            return View();
        }

        public ActionResult Frame()
        {
            DiagramdataDtoRepo testdata = new DiagramdataDtoRepo();
            testdata.genRandomisedData(10);
            ViewBag.diagramData = testdata;
            return View();
        }
        public ActionResult Home(string startDate, string stopDate)
        {
            // return "next" partial view
            return PartialView("_Home");
        }
        public ActionResult UserLogin()
        {
            // return "next" partial view
            return PartialView("_UserLogin");
        }
        public ActionResult ProductionData(string startDate, string stopDate)
        {
            ProductionDataDtoRs model = new ProductionDataDtoRs();
            return PartialView("_ProductionData", model);
        }
        public ActionResult Kvp(string startDate, string stopDate)
        {
            KvpDataDtoRs model = new KvpDataDtoRs();
            // return "next" partial view
            return PartialView("_Kvp", model);
        }
        public ActionResult Oee()
        {
            // return "next" partial view
            return PartialView("_Oee");
        }
    }
}