using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Text;

namespace kpiMvcApi.DataTransferObjects
{
    public class DiagramdataDtoRepo
    {
        public List<DiagramdataDto> DiagramDataRepo { get; set; }
        public enum charts { Testchart = 1, Debugchart };
        public DiagramdataDtoRepo()
        {
            this.DiagramDataRepo = new List<DiagramdataDto>();
        }

        public List<DiagramdataDto> genRandomisedData(int len)
        {
            Random rnd = new Random();

            for (int ic = 0; ic < len; ic++)
            {
                DiagramdataDto dddto = new DiagramdataDto
                {
                    DiagramDataId = ic,
                    DiagramDataLabel = (ic * 10).ToString(),
                    DiagramData = rnd.Next(-100, 100).ToString()
                };
                this.DiagramDataRepo.Add(dddto);
            }
            return DiagramDataRepo;
        }

        public List<DiagramdataDto> getData()
        {
            var model = new Models.kpiEntities();
            var rs = model.eDiagramdatas.FirstOrDefault(x => x.DiagramdataId == 3);
            DiagramdataDto dddto = new DiagramdataDto
            {
                DiagramDataId = rs.DiagramdataId,
                DiagramDataLabel = rs.DiagramdataLabel,
                DiagramData = rs.Diagramdata
            };
            this.DiagramDataRepo.Add(dddto);
            return this.DiagramDataRepo;
        }

        public string getChartDatastring(string chart)
        {
            var model = new Models.kpiEntities();
            var rs = model.eDiagramdatas.Where(x => x.DiagramdataId >= 0);
            StringBuilder sb = new StringBuilder("[");
            foreach (var r in rs)
            {
                sb.Append(r.Diagramdata + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
        public string getChartLabel(string chart)
        {
            var model = new Models.kpiEntities();
            var rs = model.eDiagramdatas.Where(x => x.DiagramdataId >= 0);
            StringBuilder sb = new StringBuilder("[");
            foreach (var r in rs)
            {
                sb.Append("'" + r.DiagramdataLabel + "',");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }


    }
}