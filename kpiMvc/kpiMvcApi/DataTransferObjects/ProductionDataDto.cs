using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kpiMvcApi.DataTransferObjects
{
    public class ProductionDataDto
    {
        public DateTime ProductionDay { get; set; }
        public int PcbQuantity { get; set; }
        public Decimal PcbSumPrice { get; set; }
        public int PcbGenerationId { get; set; }
        public int PcbClassId { get; set; }
        public string PcbGenerationName { get; set; }
        public string PcbClassName {get; set; }
    }
}