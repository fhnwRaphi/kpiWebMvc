using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kpiMvcApi.DataTransferObjects
{
    public class DeliveryDataDto
    {
        public int DeliveryId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderedPc { get; set; }
        public int DeliveredPc { get; set; }
        public int? NotdeliveredPc { get; set; }
        public float? NotdeliveredRel { get; set; }
        public int CountryId { get; set; }
        public string CountryName {get; set; }
    }
}