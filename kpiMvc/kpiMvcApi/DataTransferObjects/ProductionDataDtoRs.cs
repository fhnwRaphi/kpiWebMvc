using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    /// <summary>
    /// This Recordset stores a List of ProductionData Data transfer objects
    /// It prowides all Methods to read, write, update and delete data from databse
    /// It provides Methods to get HTML data for the frontend
    /// </summary>
    public class ProductionDataDtoRs: DataDtoRs
    {
        /// <summary>
        /// A List of ProductionData Data Transfer Object
        /// This List is loaded at construction
        /// and reprsent the actual Dataset
        /// </summary>
        public List<ProductionDataDto> ProductionDataRs { get; set; }

        /// <summary>
        /// Constructor loads the default data from 1.1.18 till today
        /// </summary>
        public ProductionDataDtoRs()
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
            this.loadData();
        }

        /// <summary>
        /// Constructor loads the specified id
        /// </summary>
        /// <param name="id">id of requested dataset</param>
        public ProductionDataDtoRs(int id)
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
            this.loadData(id);
        }
        /// <summary>
        ///  Constructor loads with the specified daterange
        /// </summary>
        /// <param name="startdate">dataset start date (including)</param>
        /// <param name="stopdate">dataset stop date (including)</param>
        public ProductionDataDtoRs(DateTime startdate, DateTime stopdate)
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
            this.loadData(startdate, stopdate);
        }
        /// <summary>
        /// loads the default data from 1.1.18 till today
        /// stores in object <c>ProductionData</c>
        /// </summary>
        public void loadData()
        {
            DateTime startdate = new DateTime(2018, 1, 1);
            DateTime stopdate = DateTime.Now;
            this.loadData(startdate, stopdate);
        }
        /// <summary>
        /// loads the specified dataset id
        /// stores in object <c>ProductionData</c>
        /// </summary>
        /// <param name="id">id of requested dataset</param>
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
        /// loads with the specified daterange
        /// stores in object 
        /// <c> ProductionData </c>
        /// </summary>
        /// <param name="startdate">dataset start date (including)</param>
        /// <param name="stopdate">dataset stop date (including)</param>
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

        /// <summary>
        /// Get all Data from <c>ProductionData</c> 
        /// </summary>
        /// <returns> <c> List ProductionDataDto </c>
        /// A list with in this object loaded production data
        /// </returns>
        public List<ProductionDataDto> getData()
        {
            return this.ProductionDataRs;
        }

        /// <summary>
        /// Adds Production Data into the database
        /// Generates new id for each datzaset
        /// </summary>
        /// <param name="ppdto">
        /// <c> List ProductionDataDto </c> a list of Production data data transfer object
        /// </param>
        /// <returns><c>booo</c> success</returns>
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
        /// <summary>
        /// Updates Data in the database. Adds data if the data didn't exist
        /// </summary>
        /// <param name="ppdto">
        /// <c> List ProductionDataDto </c> a list of Production data data transfer object
        /// </param>
        /// <returns><c>booo</c> success</returns>
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
        /// <summary>
        /// Delete the data by id
        /// </summary>
        /// <param name="ppdto">        
        /// <c> List ProductionDataDto </c> a list of Production data id to delete
        /// </param>
        /// <returns><c>booo</c> success</returns>
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
        /// <summary>
        /// Delete the data by dates
        /// </summary>
        /// <param name="startdate">dataset to delete start date (including)</param>
        /// <param name="stopdate">dataset to delere stop date (including)</param>
        /// <returns><c>booo</c> success</returns>
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

        /// <summary>
        /// Containing the available diagramm data val == 0 => x axis, val > 0 => y axis
        /// </summary>
        public enum dataset { Datalabels = 0, dataset1 }
        /// <summary>
        /// Containing zhe available diagramm types
        /// </summary>
        public enum charttype { Prolinechart = 0, Quantitychart }
        /// <summary>
        /// Produces Datastrings for the html / chart.js charts
        /// </summary>
        /// <param name="charttype"></param>
        /// <param name="datset"></param>
        /// <param name="filter"></param>
        /// <returns><c>string HTML.Raw Datastring</c> string for direct implementation in html.raw() view</returns>
        public string getDataset(charttype charttype, dataset datset, string filter)
        {
            StringBuilder sb = new StringBuilder("[");
            switch (charttype)
            {
                //TODO Crate interface and make bulding methods as private reuseable
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

        /// <summary>
        /// Returns the chart label
        /// </summary>
        /// <returns>string containing the Chartlabel text</returns>
        public string getDatasetLabel()
        {
            return "'Chart Label'";
        }
        /// <summary>
        /// Returns the chart colors
        /// </summary>
        /// <returns>string containing the Chart backround colors</returns>
        public string getDatsetBackroundColor()
        {
            return "'rgba(0, 12, 132, 0.2)'";
        }
        /// <summary>
        /// Returns the chart title
        /// </summary>
        /// <returns>string containing the Chart Title</returns>
        public string getChartTitle()
        {
            return "'Production Data'";
        }
        /// <summary>
        /// returns the boarer width
        /// </summary>
        /// <returns>string containing the Chart boarer width</returns>
        public int getChartBorderWidth()
        {
            return 2;
        }
    }
}
