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
    public class ExportController : Controller
    {

        public ActionResult ProdDataToExcel()
        {
            ProductionDataDtoRs pdata = new ProductionDataDtoRs();
            var gv = new GridView();
            gv.DataSource = pdata.getData();
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
    }
}