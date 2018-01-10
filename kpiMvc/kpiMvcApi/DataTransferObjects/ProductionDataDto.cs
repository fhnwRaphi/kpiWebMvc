using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kpiMvcApi.DataTransferObjects
{
    /// <summary>
    /// Represents the Production data model
    /// Transfers the data between the WebFrontend and the Database Backend
    /// </summary>
    public class ProductionDataDto
    {
        /// <summary>
        /// Dataset Id
        /// </summary>
        public int PcbDailyId { get; set; }
        /// <summary>
        /// The DateTime from the Data
        /// </summary>
        public DateTime ProductionDay { get; set; }
        /// <summary>
        /// The Pcb quantity
        /// </summary>
        public int PcbQuantity { get; set; }
        /// <summary>
        /// The sum of the pcb price, Price * PcbQuantity
        /// </summary>
        public Decimal PcbSumPrice { get; set; }
        /// <summary>
        /// The generation Id of the produced pcbs
        /// </summary>
        public int PcbGenerationId { get; set; }
        /// <summary>
        /// The class Id of the produced pcbs
        /// </summary>
        public int PcbClassId { get; set; }
        /// <summary>
        /// The PcbGenerationName of the produced pcbs
        /// </summary>
        public string PcbGenerationName { get; set; }
        /// <summary>
        /// The PcbClassName of the produced pcbs
        /// </summary>
        public string PcbClassName {get; set; }
    }
}