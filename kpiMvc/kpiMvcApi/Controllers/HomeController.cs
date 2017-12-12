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

        public ActionResult ExportToExcel()
        {
            DiagramdataDtoRepo dddtor = new DiagramdataDtoRepo();
            var gv = new GridView();
            gv.DataSource = dddtor.genRandomisedData(10);
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
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