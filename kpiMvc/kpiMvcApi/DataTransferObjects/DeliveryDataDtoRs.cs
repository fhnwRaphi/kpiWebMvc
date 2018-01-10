using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    public class DeliveryDataDtoRs
    {
        public List<DeliveryDataDto> DeliveryDataRs { get; set; }

        public DeliveryDataDtoRs()
        {
            this.DeliveryDataRs = new List<DeliveryDataDto>();
            this.loadData();
        }
        public DeliveryDataDtoRs(DateTime startdate, DateTime stopdate)
        {
            this.DeliveryDataRs = new List<DeliveryDataDto>();
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
        public List<DeliveryDataDto> getData()
        {
            this.loadData();
            return this.DeliveryDataRs;
        }
        public List<DeliveryDataDto> getData(DateTime startdate, DateTime stopdate)
        {
            this.loadData(startdate, stopdate);
            return this.DeliveryDataRs;
        }
        public bool setData(List<DeliveryDataDto> deldto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in deldto)
            {
                Models.eDelivery mdl = new Models.eDelivery();
                mdl.deliveryId = dto.DeliveryId;
                mdl.orderDate = dto.OrderDate;
                mdl.orderedPc = dto.OrderedPc;
                mdl.deliveredPc = dto.DeliveredPc;
                mdl.countryId = dto.CountryId;
                model.eDeliveries.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }

        internal bool updateData(List<DeliveryDataDto> kvpdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in kvpdto)
            {
                Models.eDelivery mdl = new Models.eDelivery();
                mdl.deliveryId = dto.DeliveryId;
                mdl.orderDate = dto.OrderDate;
                mdl.orderedPc = dto.OrderedPc;
                mdl.deliveredPc = dto.DeliveredPc;
                mdl.countryId = dto.CountryId;
                model.eDeliveries.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }

        internal bool deleteData(List<DeliveryDataDto> kvpdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();

            foreach (var dto in kvpdto)
            {
                Models.eDelivery mdl = new Models.eDelivery();
                mdl.deliveryId = dto.DeliveryId;
                model.eDeliveries.Remove(mdl);
            }
            model.SaveChanges();
            return true;
        }

        public enum dataset { Datalabels = 0, dataset1, dataset2 }
        public enum charttype { KvpMonthChart = 0 }
        public string getDataset(charttype charttype, dataset datset, string groupMode)
        {
            StringBuilder sb = new StringBuilder("[");

            switch (charttype)
            {
                case charttype.KvpMonthChart:
                    var rs = this.DeliveryDataRs.GroupBy(p => p.OrderDate.ToString(groupMode))
                         .Select(q =>
                            new
                            {
                                OrderDate = q.Key,
                                DeliveredPc = q.Sum(r => r.DeliveredPc),
                                NotdeliveredPc = q.Sum(r => r.NotdeliveredPc),
                            })
                        .OrderBy(x => x.OrderDate);
                    foreach (var r in rs)
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
                default:
                    break;
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
        public List<DeliveryDataDto> getKvpList()
        {
            return this.DeliveryDataRs;
        }
        public string getDatasetLabel()
        {
            return "'KVP Sum Monthly'";
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
    }
}
