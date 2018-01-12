using kpiMvcApi.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

/// <summary>
/// Implemts all REST API Controllers
/// </summary>
namespace kpiMvcApi.Controllers
{
    /// <summary>
    /// This Controller contains all API GET POST PUT DELETE methods
    /// </summary>
    public class KpidataController : ApiController
    {
        /// <summary>
        /// Returns the Production Data from 1.1.2018 till the actual Date
        /// </summary>
        /// <returns>
        /// Returns JSON data in the format:
        /// <code> 
        /// [
        ///    {
        ///        "PcbDailyId": 7,
        ///        "ProductionDay": "2018-01-09T00:00:00",
        ///        "PcbQuantity": 512345,
        ///        "PcbSumPrice": 5123456,
        ///        "PcbGenerationId": 3,
        ///        "PcbClassId": 0,
        ///        "PcbGenerationName": null,
        ///        "PcbClassName": null
        ///    },
        ///    {
        ///         ...
        ///    }
        /// ]
        /// </code>
        /// </returns>
        [HttpGet]
        public List<ProductionDataDto> getProductionData()
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            return prodDataRs.getData();
        }
        /// <summary>
        /// Returns the Production Data from with the specified id
        /// </summary>
        /// <param name="id">Sets the Dataid</param>
        /// <returns>Returns JSON data</returns>
        [HttpGet]
        public List<ProductionDataDto> getProductionData(int id)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs(id);
            return prodDataRs.getData();
        }
        /// <summary>
        /// Returns the Production Data between the specified Dates with the specified id
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="stopDate"></param>
        /// <returns>Returns JSON data</returns>
        [HttpGet]
        public List<ProductionDataDto> getProductionData(string startDate, string stopDate)
        {
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate);
                DateTime stopdateParsed = DateTime.Parse(stopDate);
                ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs(startdateParsed, stopdateParsed);
                return prodDataRs.getData();
            }
            catch
            {
                return this.getProductionData();
            }
        }
        /// <summary>
        /// Adds data into the database, creates new identifiers
        /// The data must hafe the following Format
        /// [
        ///    {
        ///        "ProductionDay": "2018-01-09T00:00:00",
        ///        "PcbQuantity": 512345,
        ///        "PcbSumPrice": 5123456,
        ///        "PcbGenerationId": 3,
        ///        "PcbClassId": 0,
        ///        "PcbGenerationName": null,
        ///        "PcbClassName": null
        ///    },
        ///    {
        ///         ...
        ///    }
        /// ]
        /// </summary>
        /// <param name="prodDataList"> New Dataset in Json Format </param>
        /// <returns> <c>HttpResponseMessage</c>
        /// </returns>
        [HttpPost]
        public HttpResponseMessage setProductionData(List<ProductionDataDto> prodDataList)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            prodDataRs.setData(prodDataList);
            var response = Request.CreateResponse<List<ProductionDataDto>>(System.Net.HttpStatusCode.Created, prodDataList);
            return response;
        }
        /// <summary>
        /// Adds data into the database
        /// If the Id alredy exists, update the Dataset
        /// if not create the dataset
        /// The data must hafe the following format
        /// [
        ///    {
        ///        "PcbDailyId": 8,
        ///        "ProductionDay": "2018-01-09T00:00:00",
        ///        "PcbQuantity": 512345,
        ///        "PcbSumPrice": 5123456,
        ///        "PcbGenerationId": 3,
        ///        "PcbClassId": 0,
        ///        "PcbGenerationName": null,
        ///        "PcbClassName": null
        ///    },
        ///    {
        ///         ...
        ///    }
        /// ]
        /// </summary>
        /// <param name="prodDataList"> New Dataset in Json Format </param>
        /// <returns> <c>HttpResponseMessage</c>
        /// </returns>
        [HttpPut]
        public HttpResponseMessage updateProductionData(List<ProductionDataDto> prodDataList)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            prodDataRs.updateData(prodDataList);
            var response = Request.CreateResponse<List<ProductionDataDto>>(System.Net.HttpStatusCode.Created, prodDataList);
            return response;
        }
        /// <summary>
        /// Deletes data ^with specified id from the database
        /// The data must hafe the following format
        /// [
        ///    {
        ///        "PcbDailyId": 8,
        ///    },
        ///    {
        ///         ...
        ///    }
        /// ]
        /// </summary>
        /// <param name="prodDataList"> Dataset Id to delete in Json Format </param>
        /// <returns> <c>HttpResponseMessage</c>
        /// </returns>
        [HttpDelete]
        public HttpResponseMessage deleteProductionData(List<ProductionDataDto> prodDataList)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            prodDataRs.deleteData(prodDataList);
            var response = Request.CreateResponse<List<ProductionDataDto>>(System.Net.HttpStatusCode.Created, prodDataList);
            return response;
        }
        /// <summary>
        /// Deletes data in the specified daterange
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="stopDate"></param>
        /// <returns><c>HttpResponseMessage</c>
        /// </returns>
        [HttpDelete]
        public HttpResponseMessage deleteProductionData(string startDate, string stopDate)
        {
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate);
                DateTime stopdateParsed = DateTime.Parse(stopDate);
                ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs(startdateParsed, stopdateParsed);
                var prodDataList = prodDataRs.getData();
                prodDataRs.deleteData(startdateParsed, stopdateParsed);
                var response = Request.CreateResponse<List<ProductionDataDto>>(System.Net.HttpStatusCode.Created, prodDataList);
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
        }

        [HttpGet]
        public List<KvpDataDto> getKvpData()
        {
            KvpDataDtoRs kvpDataRs = new KvpDataDtoRs();
            return kvpDataRs.getData();
        }
        [HttpGet]
        public List<KvpDataDto> getKvpData(int id)
        {
            KvpDataDtoRs kvpDataRs = new KvpDataDtoRs(id);
            return kvpDataRs.getData();
        }
        [HttpGet]
        public List<KvpDataDto> getKvpData(string startDate, string stopDate)
        {
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate);
                DateTime stopdateParsed = DateTime.Parse(stopDate);
                KvpDataDtoRs kvpDataRs = new KvpDataDtoRs(startdateParsed, stopdateParsed);
                return kvpDataRs.getData();
            }
            catch
            {
                return this.getKvpData();
            }
        }

        [HttpPost]
        public HttpResponseMessage setKvpData(List<KvpDataDto> kvpDataList)
        {
            KvpDataDtoRs kvpDataRs = new KvpDataDtoRs();
            kvpDataRs.setData(kvpDataList);
            var response = Request.CreateResponse<List<KvpDataDto>>(System.Net.HttpStatusCode.Created, kvpDataList);
            return response;
        }
        [HttpPut]
        public HttpResponseMessage updateKvpData(List<KvpDataDto> kvpDataList)
        {
            KvpDataDtoRs kvpDataRs = new KvpDataDtoRs();
            kvpDataRs.updateData(kvpDataList);
            var response = Request.CreateResponse<List<KvpDataDto>>(System.Net.HttpStatusCode.Created, kvpDataList);
            return response;
        }
        [HttpDelete]
        public HttpResponseMessage deleteKvpData(List<KvpDataDto> kvpId)
        {
            KvpDataDtoRs prodDataRs = new KvpDataDtoRs();
            prodDataRs.deleteData(kvpId);
            var response = Request.CreateResponse<List<KvpDataDto>>(System.Net.HttpStatusCode.Created, kvpId);
            return response;
        }
        /// <summary>
        /// Deletes data in the specified daterange
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="stopDate"></param>
        /// <returns><c>HttpResponseMessage</c>
        /// </returns>
        [HttpDelete]
        public HttpResponseMessage deleteKvpData(string startDate, string stopDate)
        {
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate);
                DateTime stopdateParsed = DateTime.Parse(stopDate);
                KvpDataDtoRs kvpDataRs = new KvpDataDtoRs(startdateParsed, stopdateParsed);
                var kvpDataList = kvpDataRs.getData();
                kvpDataRs.deleteData(startdateParsed, stopdateParsed);
                var response = Request.CreateResponse<List<KvpDataDto>>(System.Net.HttpStatusCode.Created, kvpDataList);
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
        }
        [HttpGet]
        public List<DeliveryDataDto> getDeliveryData()
        {
            DeliveryDataDtoRs deliveryDataRs = new DeliveryDataDtoRs();
            return deliveryDataRs.getData();
        }
        [HttpGet]
        public List<DeliveryDataDto> getDeliveryData(int id)
        {
            DeliveryDataDtoRs deliveryDataRs = new DeliveryDataDtoRs(id);
            return deliveryDataRs.getData();
        }
        [HttpGet]
        public List<DeliveryDataDto> getDeliveryData(string startDate, string stopDate)
        {
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate);
                DateTime stopdateParsed = DateTime.Parse(stopDate);
                DeliveryDataDtoRs delDataRs = new DeliveryDataDtoRs(startdateParsed, stopdateParsed);
                return delDataRs.getData();
            }
            catch
            {
                return this.getDeliveryData();
            }
        }

        [HttpPost]
        public HttpResponseMessage setDeliveryData(List<DeliveryDataDto> deliveryDataList)
        {
            DeliveryDataDtoRs deliveryDataRs = new DeliveryDataDtoRs();
            deliveryDataRs.setData(deliveryDataList);
            var response = Request.CreateResponse<List<DeliveryDataDto>>(System.Net.HttpStatusCode.Created, deliveryDataList);
            return response;
        }
        [HttpPut]
        public HttpResponseMessage updateDeliveryData(List<DeliveryDataDto> deliveryDataList)
        {
            DeliveryDataDtoRs kvpDataRs = new DeliveryDataDtoRs();
            kvpDataRs.updateData(deliveryDataList);
            var response = Request.CreateResponse<List<DeliveryDataDto>>(System.Net.HttpStatusCode.Created, deliveryDataList);
            return response;
        }
        [HttpDelete]
        public HttpResponseMessage deleteDeliveryData(List<DeliveryDataDto> deliveryDataList)
        {
            DeliveryDataDtoRs prodDataRs = new DeliveryDataDtoRs();
            prodDataRs.deleteData(deliveryDataList);
            var response = Request.CreateResponse<List<DeliveryDataDto>>(System.Net.HttpStatusCode.Created, deliveryDataList);
            return response;
        }
        /// <summary>
        /// Deletes data in the specified daterange
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="stopDate"></param>
        /// <returns><c>HttpResponseMessage</c>
        /// </returns>
        [HttpDelete]
        public HttpResponseMessage deleteDeliveryData(string startDate, string stopDate)
        {
            try
            {
                DateTime startdateParsed = DateTime.Parse(startDate);
                DateTime stopdateParsed = DateTime.Parse(stopDate);
                DeliveryDataDtoRs delDataRs = new DeliveryDataDtoRs(startdateParsed, stopdateParsed);
                var delDataList = delDataRs.getData();
                delDataRs.deleteData(startdateParsed, stopdateParsed);
                var response = Request.CreateResponse<List<DeliveryDataDto>>(System.Net.HttpStatusCode.Created, delDataList);
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
        }
    }
}

