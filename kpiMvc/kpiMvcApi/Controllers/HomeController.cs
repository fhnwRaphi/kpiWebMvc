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

/// <summary>
/// Implementiert die Controller der Dashboard Api
/// </summary>
namespace kpiMvcApi.Controllers
{
    /// <summary>
    /// Webseite Controller
    /// Setllt die Views und die Partaialviews bereit
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Test Webseite um Funktionen zu testen
        /// </summary>
        /// <returns> ActionResult IndexView</returns>
        [HttpGet]
        public ActionResult Index()
        {
            DataDtoRs testdata = new DataDtoRs();
            testdata.genRandomisedData(10);
            ViewBag.diagramData = testdata;
            return View();
        }

        /// <summary>
        /// The Dashboard Frame
        /// Returns the FrameView withe Menue and Sidebar
        /// </summary>
        /// <returns>ActionResult FrameView</returns>
        public ActionResult Frame()
        {
            DataDtoRs testdata = new DataDtoRs();
            testdata.genRandomisedData(10);
            ViewBag.diagramData = testdata;
            return View();
        }
        /// <summary>
        /// The Home View
        /// Returns the Home View with Av
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="stopDate"></param>
        /// <returns></returns>
        public ActionResult Home(string startDate, string stopDate)
        {
            return PartialView("_Home");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLogin()
        {
            return PartialView("_UserLogin");
        }

        public ActionResult ProductionData(string startDate, string stopDate)
        {
            ProductionDataDtoRs model;
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate.Substring(4, 11));
                DateTime stopdateParsed = DateTime.Parse(stopDate.Substring(4, 11));
                model = new ProductionDataDtoRs(startdateParsed, stopdateParsed);
            }
            catch
            {
                model = new ProductionDataDtoRs();
            }
            return PartialView("_ProductionData", model);
        }
        public ActionResult Kvp(string startDate, string stopDate)
        {
            KvpDataDtoRs model = new KvpDataDtoRs();
            // return "next" partial view
            return PartialView("_Kvp", model);
        }
        public ActionResult Delivery()
        {
            // return "next" partial view
            return PartialView("_Delivery");
        }
    }
}