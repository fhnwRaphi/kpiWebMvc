using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    /// <summary>
    /// This Recordset stores a List of Kvap Data transfer objects
    /// It prowides all Methods to read, write, update and delete data from databse
    /// It provides Methods to get HTML data for the frontend
    /// </summary>
    public class KvpDataDtoRs: DataDtoRs
    {
        /// <summary>
        /// A List of Kvp Data transfer Objects
        /// This List is loaded at construction
        /// and reprsent the actual Dataset
        /// </summary>
        public List<KvpDataDto> KvpDataRs { get; set; }
        
        /// <summary>
        /// Constructor loads the default data from 1.1.18 till today
        /// </summary>
        public KvpDataDtoRs()
        {
            this.KvpDataRs = new List<KvpDataDto>();
            this.loadData();
        }

        /// <summary>
        /// Constructor loads the specified id
        /// </summary>
        /// <param name="id">id of requested dataset</param>
        public KvpDataDtoRs(int id)
        {
            this.KvpDataRs = new List<KvpDataDto>();
            this.loadData(id);
        }

        /// <summary>
        ///  Constructor loads with the specified daterange
        /// </summary>
        /// <param name="startdate">dataset start date (including)</param>
        /// <param name="stopdate">dataset stop date (including)</param>
        public KvpDataDtoRs(DateTime startdate, DateTime stopdate)
        {
            this.KvpDataRs = new List<KvpDataDto>();
            this.loadData(startdate, stopdate);
        }

        /// <summary>
        /// loads the default data from 1.1.18 till today
        /// stores in object <c>KvpDataDtoRs</c>
        /// </summary>
        public void loadData()
        {
            DateTime startdate = new DateTime(2018, 1, 1);
            DateTime stopdate = DateTime.Now;
            this.loadData(startdate, stopdate);
        }

        /// <summary>
        /// loads the specified dataset id
        /// stores in object <c>KvpDataDtoRs</c>
        /// </summary>
        /// <param name="id">id of requested dataset</param>
        public void loadData(int id)
        {
            var model = new Models.kpidbEntities1();
            Models.eKvp r = model.eKvps.Where(x => x.kvpId == id).FirstOrDefault();

            KvpDataDto kvpdto = new KvpDataDto()
            {
                KvpId = r.kvpId,
                KvpDate = r.kvpDate,
                KvpName = r.kvpName,
                KvpClassId = r.eKvpClass.kvpClassId,
                KvpClassName = r.eKvpClass.kvpClassName,
                KvpStateId = r.eKvpState.kvpStateId,
                KvpStateName = r.eKvpState.kvpStateName,
            };
            this.KvpDataRs.Add(kvpdto);
        }

        /// <summary>
        /// Constructor loads with the specified daterange
        /// stores in object <c>KvpDataDtoRs</c>
        /// </summary>
        /// <param name="startdate">dataset start date (including)</param>
        /// <param name="stopdate">dataset stop date (including)</param>
        public void loadData(DateTime startdate, DateTime stopdate)
        {
            var model = new Models.kpidbEntities1();
            var rs = model.eKvps.Where(x => x.kvpDate >= startdate && x.kvpDate <= stopdate);

            foreach (var r in rs)
            {
                KvpDataDto kvpdto = new KvpDataDto()
                {
                    KvpId = r.kvpId,
                    KvpDate = r.kvpDate,
                    KvpName = r.kvpName,
                    KvpClassId = r.eKvpClass.kvpClassId,
                    KvpClassName = r.eKvpClass.kvpClassName,
                    KvpStateId = r.eKvpState.kvpStateId,
                    KvpStateName = r.eKvpState.kvpStateName,
                };
                this.KvpDataRs.Add(kvpdto);
            }
        }

        /// <summary>
        /// Get all Data from <c>KvpDataDto</c> 
        /// </summary>
        /// <returns> <c> List KvpDataDto </c>
        /// A list with in this object loaded production data
        /// </returns>
        public List<KvpDataDto> getData()
        {
            return this.KvpDataRs;
        }

        /// <summary>
        /// Adds Kvp Data into the database
        /// Generates new id for each datzaset
        /// </summary>
        /// <param name="kvpdto">
        /// <c> List KvpDataDto </c> a list of Kvp data data transfer object
        /// </param>
        /// <returns><c>booo</c> success</returns>
        public bool setData(List<KvpDataDto> kvpdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in kvpdto)
            {
                Models.eKvp mdl = new Models.eKvp();
                mdl.kvpDate = dto.KvpDate;
                mdl.kvpName = dto.KvpName;
                mdl.kvpClassId = dto.KvpClassId;
                mdl.kvpStateId = dto.KvpStateId;
                model.eKvps.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }

        /// <summary>
        /// Updates Data in the database. Adds data if the data didn't exist
        /// </summary>
        /// <param name="kvpdto">
        /// <c> List KvpDataDto </c> a list of Kvp data data transfer object
        /// </param>
        /// <returns><c>booo</c> success</returns>
        internal bool updateData(List<KvpDataDto> kvpdto)
        {
            var ctx = new Models.kpidbEntities1();

            foreach (var dto in kvpdto)
            {
                bool add = false;
                Models.eKvp mdl = ctx.eKvps.Where(x => x.kvpId == dto.KvpId).FirstOrDefault();
                if (mdl == null)
                {
                    add = true;
                    mdl = new Models.eKvp();
                }
                mdl.kvpDate = dto.KvpDate;
                mdl.kvpName = dto.KvpName;
                mdl.kvpClassId = dto.KvpClassId;
                mdl.kvpStateId = dto.KvpStateId;
                if (add == true)
                {
                    ctx.eKvps.Add(mdl);
                }
            }
            ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// Delete the data by id
        /// </summary>
        /// <param name="kvpdto">        
        /// <c> List KvpDataDto </c> a list of Kvp data id to delete
        /// </param>
        /// <returns><c>booo</c> success</returns>
        internal bool deleteData(List<KvpDataDto> kvpdto)
        {
            var ctx = new Models.kpidbEntities1();

            foreach (var dto in kvpdto)
            {
                Models.eKvp mdl = ctx.eKvps.Where(x => x.kvpId == dto.KvpId).FirstOrDefault();

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
            var rs = ctx.eKvps.Where(x => x.kvpDate >= startdate && x.kvpDate <= stopdate);

            foreach (var r in rs)
            {
                Models.eKvp mdl = ctx.eKvps.Where(x => x.kvpId == r.kvpId).FirstOrDefault();
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
        public enum charttype { KvpMonthChart = 0, KvpClassChart }

        /// <summary>
        /// Produces Datastrings for the html / chart.js charts
        /// </summary>
        /// <param name="charttype"></param>
        /// <param name="datset"></param>
        /// <param name="filter">"y" year, "M" month, "d" day</param>
        /// <returns><c>string HTML.Raw Datastring</c> string for direct implementation in html.raw() view</returns>
        public string getDataset(charttype charttype, dataset datset, string filter)
        {
            StringBuilder sb = new StringBuilder("[");

            switch (charttype)
            {
                case charttype.KvpMonthChart:
                    var rsQ = this.KvpDataRs.GroupBy(p => p.KvpDate.ToString(filter))
                         .Select(q =>
                            new
                            {
                                KvpDate = q.Key,
                                kvpSortDate = q.Max(r => r.KvpDate),
                                KvpQuantity = q.Count(r => r.KvpId >= 0)
                            })
                        .OrderBy(x => x.kvpSortDate);
                    foreach (var r in rsQ)
                    {
                        switch (datset)
                        {
                            case dataset.Datalabels:
                                sb.Append("'" + r.KvpDate + "',");
                                break;
                            case dataset.dataset1:
                                sb.Append("'" + r.KvpQuantity + "',");
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case charttype.KvpClassChart:
                    var rsClass = this.KvpDataRs.GroupBy(p => p.KvpClassName)
                         .Select(q =>
                            new
                            {
                                KvpClassName = q.Key,
                                KvpQuantity = q.Count(r => r.KvpClassName != "")
                            })
                        .OrderBy(x => x.KvpClassName);
                    foreach (var r in rsClass)
                    {
                        switch (datset)
                        {
                            case dataset.Datalabels:
                                sb.Append("'" + r.KvpClassName + "',");
                                break;
                            case dataset.dataset1:
                                sb.Append("'" + r.KvpQuantity + "',");
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
        /// Returns the kvp list
        /// </summary>
        /// <returns>string containing the Chartlabel text</returns>
        public List<KvpDataDto> getKvpList()
        {
            return this.KvpDataRs;
        }

        /// <summary>
        /// Returns the chart label
        /// </summary>
        /// <returns>string containing the Chartlabel text</returns>
        public string getDatasetLabel()
        {
            return "'KVP Sum Pc'";
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
            return "'KVP Data'";
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
