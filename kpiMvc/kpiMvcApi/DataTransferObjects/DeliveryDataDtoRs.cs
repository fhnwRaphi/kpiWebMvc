using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    /// <summary>
    /// This Recordset stores a List of Delivery Data transfer objects
    /// It prowides all Methods to read, write, update and delete data from databse
    /// It provides Methods to get HTML data for the frontend
    /// </summary>
    public class DeliveryDataDtoRs : DataDtoRs
    {
        /// <summary>
        /// A List of Delivery Data transfer Objects
        /// This List is loaded at construction
        /// and reprsent the actual Dataset
        /// </summary>
        public List<DeliveryDataDto> DeliveryDataRs { get; set; }

        /// <summary>
        /// Constructor loads the default data from 1.1.18 till today
        /// </summary>
        public DeliveryDataDtoRs()
        {
            this.DeliveryDataRs = new List<DeliveryDataDto>();
            this.loadData();
        }

        /// <summary>
        /// Constructor loads the specified id
        /// </summary>
        /// <param name="id">id of requested dataset</param>
        public DeliveryDataDtoRs(int id)
        {
            this.DeliveryDataRs = new List<DeliveryDataDto>();
            this.loadData(id);
        }

        /// <summary>
        ///  Constructor loads with the specified daterange
        /// </summary>
        /// <param name="startdate">dataset start date (including)</param>
        /// <param name="stopdate">dataset stop date (including)</param>
        public DeliveryDataDtoRs(DateTime startdate, DateTime stopdate)
        {
            this.DeliveryDataRs = new List<DeliveryDataDto>();
            this.loadData(startdate, stopdate);
        }

        /// <summary>
        /// loads the default data from 1.1.18 till today
        /// stores in object <c>DeliveryDataDtoRs</c>
        /// </summary>
        public void loadData()
        {
            DateTime startdate = new DateTime(2018, 1, 1);
            DateTime stopdate = DateTime.Now;
            this.loadData(startdate, stopdate);
        }

        /// <summary>
        /// loads the specified dataset id
        /// stores in object <c>DeliveryDataDtoRs</c>
        /// </summary>
        /// <param name="id">id of requested dataset</param>
        public void loadData(int id)
        {
            var model = new Models.kpidbEntities1();
            Models.eDelivery r = model.eDeliveries.Where(x => x.deliveryId == id).FirstOrDefault();

            DeliveryDataDto deldto = new DeliveryDataDto()
            {
                DeliveryId = r.deliveryId,
                OrderDate = r.orderDate,
                OrderedPc = r.orderedPc,
                DeliveredPc = r.deliveredPc,
                CountryId = r.eCountry.countryId,
                CountryName = r.eCountry.countryName,
            };
            this.DeliveryDataRs.Add(deldto);
        }

        /// <summary>
        /// Constructor loads with the specified daterange
        /// stores in object <c>DeliveryDataDtoRs</c>
        /// </summary>
        /// <param name="startdate">dataset start date (including)</param>
        /// <param name="stopdate">dataset stop date (including)</param>
        public void loadData(DateTime startdate, DateTime stopdate)
        {
            var model = new Models.kpidbEntities1();
            var rs = model.eDeliveries.Where(x => x.orderDate >= startdate && x.orderDate <= stopdate);

            foreach (var r in rs)
            {
                DeliveryDataDto deldto = new DeliveryDataDto()
                {
                    DeliveryId = r.deliveryId,
                    OrderDate = r.orderDate,
                    OrderedPc = r.orderedPc,
                    DeliveredPc = r.deliveredPc,
                    CountryId = r.eCountry.countryId,
                    CountryName = r.eCountry.countryName,
                };
                this.DeliveryDataRs.Add(deldto);
            }
        }

        /// <summary>
        /// Get all Data from <c>DeliveryDataDtoRs</c> 
        /// </summary>
        /// <returns> <c> List DeliveryDataDtoRs </c>
        /// A list with in this object loaded production data
        /// </returns>
        public List<DeliveryDataDto> getData()
        {
            return this.DeliveryDataRs;
        }

        /// <summary>
        /// Adds Kvp Data into the database
        /// Generates new id for each dataset
        /// </summary>
        /// <param name="deldto">
        /// <c> List DeliveryDataDtoRs </c> a list of Kvp data data transfer object
        /// </param>
        /// <returns><c>booo</c> success</returns>
        public bool setData(List<DeliveryDataDto> deldto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in deldto)
            {
                Models.eDelivery mdl = new Models.eDelivery();
                mdl.orderDate = dto.OrderDate;
                mdl.orderedPc = dto.OrderedPc;
                mdl.deliveredPc = dto.DeliveredPc;
                mdl.countryId = dto.CountryId;
                model.eDeliveries.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }

        /// <summary>
        /// Updates Data in the database. Adds data if the data didn't exist
        /// </summary>
        /// <param name="deldto">
        /// <c> List DeliveryDataDtoRs </c> a list of Delivery data data transfer object
        /// </param>
        /// <returns><c>booo</c> success</returns>
        internal bool updateData(List<DeliveryDataDto> deldto)
        {
            var ctx = new Models.kpidbEntities1();

            foreach (var dto in deldto)
            {
                bool add = false;
                Models.eDelivery mdl = ctx.eDeliveries.Where(x => x.deliveryId == dto.DeliveryId).FirstOrDefault();
                if (mdl == null)
                {
                    add = true;
                    mdl = new Models.eDelivery();
                }
                mdl.orderDate = dto.OrderDate;
                mdl.orderedPc = dto.OrderedPc;
                mdl.deliveredPc = dto.DeliveredPc;
                mdl.countryId = dto.CountryId;
                if (add == true)
                {
                    ctx.eDeliveries.Add(mdl);
                }
            }
            ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// Delete the data by id
        /// </summary>
        /// <param name="deldto">        
        /// <c> List KvpDataDto </c> a list of Kvp data id to delete
        /// </param>
        /// <returns><c>booo</c> success</returns>
        internal bool deleteData(List<DeliveryDataDto> deldto)
        {
            var ctx = new Models.kpidbEntities1();

            foreach (var dto in deldto)
            {
                Models.eDelivery mdl = ctx.eDeliveries.Where(x => x.deliveryId == dto.DeliveryId).FirstOrDefault();
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
            var rs = ctx.eDeliveries.Where(x => x.orderDate >= startdate && x.orderDate <= stopdate);

            foreach (var r in rs)
            {
                Models.eDelivery mdl = ctx.eDeliveries.Where(x => x.deliveryId == r.deliveryId).FirstOrDefault();
                ctx.Entry(mdl).State = System.Data.Entity.EntityState.Deleted;
            }
            ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// Containing the available diagramm data val == 0 => x axis, val > 0 => y axis
        /// </summary>
        public enum dataset { Datalabels = 0, dataset1, dataset2 }

        /// <summary>
        /// Containing zhe available diagramm types
        /// </summary>
        public enum charttype { DeliveryDaily = 0, DeliveryCountry }

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
                case charttype.DeliveryDaily:
                    var rsD = this.DeliveryDataRs.GroupBy(p => p.OrderDate.ToString(filter))
                         .Select(q =>
                            new
                            {
                                OrderDate = q.Key,
                                DeliveredPc = q.Sum(r => r.DeliveredPc),
                                NotdeliveredPc = q.Sum(r => r.NotdeliveredPc),
                            })
                        .OrderBy(x => x.OrderDate);
                    foreach (var r in rsD)
                    {
                        switch (datset)
                        {
                            case dataset.Datalabels:
                                sb.Append("'" + r.OrderDate + "',");
                                break;
                            case dataset.dataset1:
                                sb.Append("'" + r.DeliveredPc + "',");
                                break;
                            case dataset.dataset2:
                                sb.Append("'" + r.NotdeliveredPc + "',");
                                break;
                            default:
                                break;
                        }
                    }
                    break;

                case charttype.DeliveryCountry:
                    var rsC = this.DeliveryDataRs.GroupBy(p => p.CountryName)
                         .Select(q =>
                            new
                            {
                                CountryName = q.Key,
                                DeliveredPc = q.Sum(r => r.DeliveredPc),
                            })
                        .OrderBy(x => x.CountryName);
                    foreach (var r in rsC)
                    {
                        switch (datset)
                        {
                            case dataset.Datalabels:
                                sb.Append("'" + r.CountryName + "',");
                                break;
                            case dataset.dataset1:
                                sb.Append("'" + r.DeliveredPc + "',");
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
        /// Returns the delivery label
        /// </summary>
        /// <returns>string containing the Chartlabel text</returns>
        public List<DeliveryDataDto> getDeliveryList()
        {
            return this.DeliveryDataRs;
        }
        public string getDatasetLabel(charttype charttype, dataset dataset)
        {
            switch (charttype)
            {
                case charttype.DeliveryDaily:                                     
                        switch (dataset)
                        {
                            case dataset.dataset1:
                                return "'Delivered'";
                                break;
                            case dataset.dataset2:
                                return "'Not Delivered'";
                                break;
                        default:
                                return "''";
                                break;
                        };
                        break;
                default:
                    return "''";
                    break;
            }
        }
        public string getDatsetBackroundColor()
        {
            return "'rgba(0, 12, 132, 0.2)'";
        }
        public string getChartTitle(charttype charttype)
        {
            switch (charttype)
            {
                case charttype.DeliveryDaily:
                    return "'Delivery Data'";
                    break;
                case charttype.DeliveryCountry:
                    return "'Delivery Country'";
                    break;
                default:
                    return "''";
                    break;
            }
        }
        public int getChartBorderWidth()
        {
            return 2;
        }
    }
}
