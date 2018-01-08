using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    public class ProductionDataDtoRs
    {
        public List<ProductionDataDto> ProductionDataRs { get; set; }

        public ProductionDataDtoRs()
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
            this.loadData();
        }
        public ProductionDataDtoRs(DateTime startdate, DateTime stopdate)
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
            this.loadData(startdate, stopdate);
        }
        public void loadData()
        {
            DateTime startdate = new DateTime(2018, 1, 1);
            DateTime stopdate = DateTime.Now;
            this.loadData(startdate, stopdate);
        }
        public void loadData(DateTime startdate, DateTime stopdate)
        {
            var model = new Models.kpidbEntities1();
            var rs = model.ePcbDailies.Where(x => x.productionDay >= startdate && x.productionDay <= stopdate);

            foreach (var r in rs)
            {
                ProductionDataDto pddto = new ProductionDataDto()
                {
                    PcbDailyId = r.pcbDailyId,
                    ProductionDay = r.productionDay,
                    PcbQuantity = r.pcbQuantity,
                    PcbSumPrice = r.pcbSumPrice,
                    PcbGenerationId = r.pcbGenerationId,
                    PcbClassId = r.pcbClassId,
                    PcbGenerationName = r.ePcbGeneration.genName,
                    PcbClassName = r.ePcbClass.ClassName
                };
                this.ProductionDataRs.Add(pddto);
            }
        }
        public List<ProductionDataDto> getData()
        {
            this.loadData();
            return this.ProductionDataRs;
        }
        public List<ProductionDataDto> getData(DateTime startdate, DateTime stopdate)
        {
            this.loadData(startdate, stopdate);
            return this.ProductionDataRs;
        }
        public bool setData(List<ProductionDataDto> ppdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in ppdto)
            {
                Models.ePcbDaily mdl = new Models.ePcbDaily();
                mdl.pcbGenerationId = dto.PcbGenerationId;
                mdl.pcbClassId = dto.PcbClassId;
                mdl.pcbQuantity = dto.PcbQuantity;
                mdl.pcbSumPrice = dto.PcbSumPrice;
                mdl.productionDay = dto.ProductionDay;
                model.ePcbDailies.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }

        internal bool updateData(List<ProductionDataDto> kvpdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in kvpdto)
            {
                Models.ePcbDaily mdl = new Models.ePcbDaily();
                mdl.pcbGenerationId = dto.PcbGenerationId;
                mdl.pcbClassId = dto.PcbClassId;
                mdl.pcbQuantity = dto.PcbQuantity;
                mdl.pcbSumPrice = dto.PcbSumPrice;
                mdl.productionDay = dto.ProductionDay;
                model.ePcbDailies.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }

        internal bool deleteData(List<ProductionDataDto> kvpdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();

            foreach (var dto in kvpdto)
            {
                Models.ePcbDaily mdl = new Models.ePcbDaily();
                mdl.pcbDailyId = dto.PcbDailyId;
                model.ePcbDailies.Remove(mdl);
            }
            return true;
        }


        public enum dataset { Datalabels = 0, dataset1 }
        public enum charttype { Prolinechart=0}

        public string getDataset(charttype charttype, dataset datset )
        {
            StringBuilder sb = new StringBuilder("[");
            switch (charttype)
            {
                case charttype.Prolinechart:
                    var rs = this.ProductionDataRs.GroupBy(p => p.PcbGenerationName)
                        .Select(q =>
                           new
                           {
                               PcbGenerationName = q.Key,
                               PcbQuantity = q.Sum(w => w.PcbQuantity)
                           })
                       .OrderBy(x => x.PcbGenerationName);
                    foreach (var r in rs)
                    {
                        switch (datset)
                        {
                            case dataset.Datalabels:
                                sb.Append("'" + r.PcbGenerationName + "',");
                                break;
                            case dataset.dataset1:
                                sb.Append("'" + r.PcbQuantity + "',");
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        public string getDataset()
        {
            StringBuilder sb = new StringBuilder("[");
            var rs = this.ProductionDataRs.GroupBy(p => p.ProductionDay.ToString("M"))
                .Select(q =>
                   new
                   {
                       ProductionDay = q.Key,
                       PcbQuantity = q.Sum(w => w.PcbQuantity)
                   })
               .OrderBy(x => x.ProductionDay);
            foreach (var r in rs)
            {
                sb.Append(r.PcbQuantity + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
        public string getChartLabels()
        {
            var rs = this.ProductionDataRs.GroupBy(p => p.ProductionDay.ToString("M"))
                .Select(q =>
                   new
                   {
                       ProductionDay = q.Key,
                       PcbQuantity = q.Sum(w => w.PcbQuantity)
                   })
                 .OrderBy(x => x.ProductionDay);

            StringBuilder sb = new StringBuilder("[");
            foreach (var r in rs)
            {
                sb.Append("'" + r.ProductionDay + "',");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
        public string getDatasetLabel()
        {
            return "'Chart Label'";
        }
        public string getDatsetBackroundColor()
        {
            return "'rgba(0, 12, 132, 0.2)'";
        }
        public string getChartTitle()
        {
            return "'Production Data'";
        }
        public int getChartBorderWidth()
        {
            return 2;
        }
        public string getChartHeigh()
        {
            return "400";
        }
        public string getChartWidth()
        {
            return "600";
        }
    }
}
