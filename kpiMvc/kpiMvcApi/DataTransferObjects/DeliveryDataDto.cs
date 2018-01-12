using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kpiMvcApi.DataTransferObjects
{
    /// <summary>
    /// Represents the dekivery data model
    /// Transfers the data between the WebFrontend and the Database Backend
    /// </summary>
    public class DeliveryDataDto : DataDto
    {
        /// <summary>
        /// The Database Kvp Id
        /// </summary>
        public int DeliveryId { get; set; }

        /// <summary>
        /// The Date the Pcbs were ordered
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// The Sum of Pcbs that was ordered
        /// </summary>
        public int OrderedPc { get; set; }

        /// <summary>
        /// The Deliverd Pcbs for this order
        /// </summary>
        public int DeliveredPc { get; set; }

        /// <summary>
        /// The not deliverd Pcb's for this Orders
        /// </summary>
        public int? NotdeliveredPc { get; set; }

        /// <summary>
        /// The not deliverd Pcb's for this Orders in %
        /// </summary>
        public float? NotdeliveredRel { get; set; }

        /// <summary>
        /// The Destination Country Id
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// The Destination Country Name
        /// countryId	countryName
        /// <list type="bullet" | "number" | "table">  
        /// 0	generic
        /// 1	Switzerland
        /// 2	France
        /// 3	USA
        /// 4	India
        /// 5	China
        /// 6	Brasil
        /// </list>
        /// </summary>
        public string CountryName { get; set; }
    }
}