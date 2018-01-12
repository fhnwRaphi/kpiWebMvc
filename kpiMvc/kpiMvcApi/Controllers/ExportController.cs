using kpiMvcApi.DataTransferObjects;
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
    /// <summary>
    /// Der Exportkontroller stellt den alle Dienste zur exportierung von Files zur Verfügung.
    /// </summary>
    public class ExportController : Controller
    {
        /// <summary>
        /// Exportier die Daten welche in einer Gridview übergeben werden in ein Excell File
        /// </summary>
        /// <param name="gv"></param>
        /// <returns></returns>
        private ActionResult exportExcell(GridView gv)
        {
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=ProdData.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return View();
        }
        /// <summary>
        /// Nimmt daten aus dem Production Data Data Transfer Object Recordset
        /// Bindet die Daten in eine Gridview
        /// Exportiert die Daten in eine Excell.xls
        /// </summary>
        /// <returns> View() Excell .xls File </returns>
        public ActionResult ProdDataToExcel()
        {
            ProductionDataDtoRs pdata = new ProductionDataDtoRs();
            var gv = new GridView();
            gv.DataSource = pdata.getData();

            return this.exportExcell(gv);
        }
        /// <summary>
        /// Nimmt daten aus dem Kvp Data Data Transfer Object Recordset
        /// Bindet die Daten in eine Gridview
        /// Exportiert die Daten in eine Excell.xls
        /// </summary>
        /// <returns> View() Excell .xls File </returns>
        public ActionResult KvpDataToExcel()
        {
            KvpDataDtoRs kvpdata = new KvpDataDtoRs();
            var gv = new GridView();
            gv.DataSource = kvpdata.getData();

            return this.exportExcell(gv);
        }
        /// <summary>
        /// Nimmt daten aus dem Deliovery Data Data Transfer Object Recordset
        /// Bindet die Daten in eine Gridview
        /// Exportiert die Daten in eine Excell.xls
        /// </summary>
        /// <returns> View() Excell .xls File </returns>
        public ActionResult DeliveryDataToExcel()
        {
            DeliveryDataDtoRs delivData = new DeliveryDataDtoRs();
            var gv = new GridView();
            gv.DataSource = delivData.getData();

            return this.exportExcell(gv);
        }
    }
}