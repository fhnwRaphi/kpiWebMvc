using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kpiMvcApi.DataTransferObjects
{
    /// <summary>
    /// Represents the Kvp data model
    /// Transfers the data between the WebFrontend and the Database Backend
    /// </summary>
    public class KvpDataDto : DataDto
    {
        /// <summary>
        /// The Database Kvp Id
        /// </summary>
        public int KvpId { get; set; }

        /// <summary>
        /// The Header of the Kvp
        /// </summary>
        public string KvpName { get; set; }

        /// <summary>
        /// The creation date the Kvp was created
        /// </summary>
        public DateTime KvpDate { get; set; }

        /// <summary>
        /// The Class Id of the Kvp
        /// </summary>
        public int KvpClassId { get; set; }

        /// <summary>
        /// The State Id of the Kvp
        /// </summary>
        public int KvpStateId { get; set; }

        /// <summary>
        /// The Statename
        /// 0	generic
        /// 1	Plan
        /// 2	Do
        /// 3	Check
        /// 4	Act
        /// </summary>
        public string KvpStateName { get; set; }

        /// <summary>
        /// The Classname
        /// 0	generic
        /// 1	Qualität
        /// 2	Produktivität
        /// 3	Umwelt
        /// </summary>
        public string KvpClassName { get; set; }
    }
}