using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    public class KvpDataDtoRs
    {
        public List<KvpDataDto> KvpDataRs { get; set; }

        public KvpDataDtoRs()
        {
            this.KvpDataRs = new List<KvpDataDto>();
            this.loadData();
        }
        public KvpDataDtoRs(DateTime startdate, DateTime stopdate)
        {
            this.KvpDataRs = new List<KvpDataDto>();
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
        public List<KvpDataDto> getData()
        {
            this.loadData();
            return this.KvpDataRs;
        }
        public List<KvpDataDto> getData(DateTime startdate, DateTime stopdate)
        {
            this.loadData(startdate, stopdate);
            return this.KvpDataRs;
        }
        public bool setData(List<KvpDataDto> kvpdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in kvpdto)
            {
                Models.eKvp mdl = new Models.eKvp();
                mdl.kvpId = dto.KvpId;
                mdl.kvpDate = dto.KvpDate;
                mdl.kvpName = dto.KvpName;
                mdl.kvpClassId = dto.KvpClassId;
                mdl.kvpStateId = dto.KvpStateId;
                model.eKvps.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }

        public enum dataset { Datalabels = 0, dataset1 }
        public enum charttype {KvpMonthChart=0}
        public string getDataset(charttype charttype, dataset datset, string groupMode)
        {
            StringBuilder sb = new StringBuilder("[");

            switch (charttype)
            {
                case charttype.KvpMonthChart:
                   var rs = this.KvpDataRs.GroupBy(p => p.KvpDate.ToString(groupMode))
                        .Select(q =>
                           new
                           {
                               KvpId = q.Key,
                               KvpQuantity = q.Count(r => r.KvpId >= 0)
                           })
                       .OrderBy(x => x.KvpId);
                    foreach (var r in rs)
                    {
                        switch (datset)
                        {
                            case dataset.Datalabels:
                                sb.Append("'" + r.KvpId + "',");
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
        public List<KvpDataDto> getKvpList()
        {
            return this.KvpDataRs;
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
