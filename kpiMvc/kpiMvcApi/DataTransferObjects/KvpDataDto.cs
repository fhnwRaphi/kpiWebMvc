using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kpiMvcApi.DataTransferObjects
{
    public class KvpDataDto
    {
        public int KvpId { get; set; }
        public string KvpName { get; set; }
        public DateTime KvpDate { get; set; }
        public int KvpClassId { get; set; }
        public int KvpStateId { get; set; }
        public string KvpStateName { get; set; }
        public string KvpClassName {get; set; }
    }
}