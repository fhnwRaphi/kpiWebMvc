using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    /// <summary>
    /// This Recordset stores a List of ProductionData Data transfer object
    /// It prowides all Methods to read, write, update and delete date from databse
    /// It provides Methods to provides HTML data for the frontend
    /// </summary>
    public class ProductionDataDtoRs
    {
        /// <summary>
        /// A List of ProductionData Data Transfer Object
        /// This List is loaded at construction
        /// and reprsent the actual Dataset
        /// </summary>
        public List<ProductionDataDto> ProductionDataRs { get; set; }


        public ProductionDataDtoRs()
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
            this.loadData();
        }
        public ProductionDataDtoRs(int id)
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
            this.loadData(id);
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
        public void loadData(int id)
        {
            var model = new Models.kpidbEntities1();
            Models.ePcbDaily r = model.ePcbDailies.Where(x => x.pcbDailyId == id).FirstOrDefault();

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

        /// <summary>
        /// Get all Data From ProductionDataDto 
        /// </summary>
        /// <returns></returns>
        public List<ProductionDataDto> getData()
        {
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

        internal bool updateData(List<ProductionDataDto> ppdto)
        {
            var ctx = new Models.kpidbEntities1();

            foreach (var dto in ppdto)
            {
                Models.ePcbDaily mdl = ctx.ePcbDailies.Where(x => x.pcbDailyId == dto.PcbDailyId).FirstOrDefault();

                if(mdl == null)
                {
                    mdl = new Models.ePcbDaily();
                }
                mdl.pcbGenerationId = dto.PcbGenerationId;
                mdl.pcbClassId = dto.PcbClassId;
                mdl.pcbQuantity = dto.PcbQuantity;
                mdl.pcbSumPrice = dto.PcbSumPrice;
                mdl.productionDay = dto.ProductionDay;
            }
            ctx.SaveChanges();
            return true;
        }

        internal bool deleteData(List<ProductionDataDto> ppdto)
        {
            var ctx = new Models.kpidbEntities1();

            foreach (var dto in ppdto)
            {
                Models.ePcbDaily mdl = ctx.ePcbDailies.Where(x => x.pcbDailyId == dto.PcbDailyId).FirstOrDefault();
                ctx.Entry(mdl).State = System.Data.Entity.EntityState.Deleted;
            }
            ctx.SaveChanges();
            return true;
        }
        internal bool deleteData(DateTime startdate, DateTime stopdate)
        {
            var ctx = new Models.kpidbEntities1();
            var rs = ctx.ePcbDailies.Where(x => x.productionDay >= startdate && x.productionDay <= stopdate);

            foreach (var r in rs)
            {
                Models.ePcbDaily mdl = ctx.ePcbDailies.Where(x => x.pcbDailyId == r.pcbDailyId).FirstOrDefault();
                ctx.Entry(mdl).State = System.Data.Entity.EntityState.Deleted;
            }
            ctx.SaveChanges();
            return true;
        }


        public enum dataset { Datalabels = 0, dataset1 }
        public enum charttype { Prolinechart = 0, Quantitychart }

        public string getDataset(charttype charttype, dataset datset, string filter)
        {
            StringBuilder sb = new StringBuilder("[");
            switch (charttype)
            {
                case charttype.Prolinechart:
                    var rsPd = this.ProductionDataRs.GroupBy(p => p.PcbGenerationName)
                        .Select(q =>
                           new
                           {
                               PcbGenerationName = q.Key,
                               PcbQuantity = q.Sum(w => w.PcbQuantity)
                           })
                       .OrderBy(x => x.PcbGenerationName);
                    foreach (var r in rsPd)
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

                case charttype.Quantitychart:
                    var rsQ = this.ProductionDataRs.GroupBy(p => p.ProductionDay.ToString(filter))
                        .Select(q =>
                           new
                           {
                               PcbGenerationName = q.Key,
                               PcbQuantity = q.Sum(w => w.PcbQuantity)
                           })
                       .OrderBy(x => x.PcbGenerationName);
                    foreach (var r in rsQ)
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
