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
        /// <returns> <c> ActionResult IndexView </c>
        /// Die Index View
        /// </returns>
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    //DataDtoRs testdata = new DataDtoRs();
        //    //testdata.genRandomisedData(10);
        //    //ViewBag.diagramData = testdata;
        //    //return View();
        //}

        /// <summary>
        /// Das Dashboard Fenster
        /// </summary>
        /// <returns><c>ActionResult FrameView</c>
        /// Giebt die FrameView zurück. Diese Beinhaltet die Sidebar und die Menueleiste.
        /// </returns>
        public ActionResult Frame()
        {
            return View();
        }
        /// <summary>
        /// Das Home Fenster
        /// </summary>
        /// <returns><c>ActionResult _HomeView</c>
        /// Giebt die HomeView als Partielle View zurück. Diese Beinhaltet die übersicht über Verfügbare Dashboards
        /// </returns>
        public ActionResult Home()
        {
            return PartialView("_Home");
        }
        /// <summary>
        /// Das User Login Fenster
        /// Returns the View to login a User
        /// </summary>
        /// <returns><c>ActionResult _UserLoginView</c>
        /// Giebt die _UserLoginView als Partielle View zurück. Diese Beinhaltet die Funktion um den User einzuloggen
        /// </returns>
        public ActionResult UserLogin()
        {
            return PartialView("_UserLogin");
        }

        /// <summary>
        /// Das Production Data Fenster
        /// Versucht einen Date String in eine DateTime Class zu arsen
        /// Der Datensatz wird über diese Datumswerte gefiltert
        /// Für nicht gültige Datumswerte wird ein standardatum von 1.1.18 bis zum aktuellen Tag gewählt
        /// </summary>
        /// <param name="startDate">The Date the Dataset starts</param>
        /// <param name="stopDate">The Date the Dataset stops </param>
        /// <returns>
        /// <c>ActionResult PartialView("_ProductionData", model);</c> 
        /// The View containing all selected Production Date, shown as a diagram and a table. Also provide an Excell export function
        /// </returns>
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
        /// <summary>
        /// The KVP View
        /// Tries to parse the Date Strings to DateTime Class
        /// The Data is filtered by these Parameters
        /// For nonvalid Dates the Standarddate will be loaded
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="stopDate"></param>
        /// <returns>
        /// <c>PartialView("_Kvp", model);</c> 
        /// The View Containing all selected KVP Data, shown as a diagram and a List. Also provide an Excell export function
        /// </returns>
        public ActionResult Kvp(string startDate, string stopDate)
        {
            KvpDataDtoRs model;
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate.Substring(4, 11));
                DateTime stopdateParsed = DateTime.Parse(stopDate.Substring(4, 11));
                model = new KvpDataDtoRs(startdateParsed, stopdateParsed);
            }
            catch
            {
                model = new KvpDataDtoRs();
            }
            return PartialView("_Kvp", model);
        }
        /// <summary>
        /// The Delivery View
        /// Tries to parse the Date Strings to DateTime Class
        /// The Data is filtered by these Parameters
        /// For nonvalid Dates the Standarddate will be loaded
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="stopDate"></param>
        /// <returns>
        /// <c>PartialView("_Delivery", model);</c> 
        /// The View Containing all selected Delivery Data, shown as a diagram and a Table. Also provide an Excell export function
        /// </returns>
        public ActionResult Delivery(string startDate, string stopDate)
        {
            DeliveryDataDtoRs model;
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate.Substring(4, 11));
                DateTime stopdateParsed = DateTime.Parse(stopDate.Substring(4, 11));
                model = new DeliveryDataDtoRs(startdateParsed, stopdateParsed);
            }
            catch
            {
                model = new DeliveryDataDtoRs();
            }
            return PartialView("_Delivery", model);
        }
    }
}