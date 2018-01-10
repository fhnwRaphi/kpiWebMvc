using kpiMvcApi.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace kpiMvcApi.Controllers
{
    /// <summary>
    /// This Controller contains all API GET POST PUT DELETE methods
    /// </summary>
    public class KpidataController : ApiController
    {

        [HttpGet]
        public List<ProductionDataDto> getProductionData()
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            return prodDataRs.getData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Sets the Dataid</param>
        /// <returns></returns>
        [HttpGet]
        public List<ProductionDataDto> getProductionData(int id)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            return prodDataRs.getData((int)id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Sets the Dataid</param>
        /// <returns></returns>
        [HttpGet]
        public List<ProductionDataDto> getProductionData(string startdate, string stopdate)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            return prodDataRs.getData();
        }
        [HttpPost]
        public HttpResponseMessage setProductionData(List<ProductionDataDto> prodDataList)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            prodDataRs.setData(prodDataList);
            var response = Request.CreateResponse<List<ProductionDataDto>>(System.Net.HttpStatusCode.Created, prodDataList);
            return response;
        }
        [HttpPut]
        public HttpResponseMessage updateProductionData(List<ProductionDataDto> prodDataList)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            prodDataRs.updateData(prodDataList);
            var response = Request.CreateResponse<List<ProductionDataDto>>(System.Net.HttpStatusCode.Created, prodDataList);
            return response;
        }
        [HttpDelete]
        public HttpResponseMessage deleteProductionData(List<ProductionDataDto> prodDataList)
        {
            ProductionDataDtoRs prodDataRs = new ProductionDataDtoRs();
            prodDataRs.deleteData(prodDataList);
            var response = Request.CreateResponse<List<ProductionDataDto>>(System.Net.HttpStatusCode.Created, prodDataList);
            return response;
        }

        [HttpGet]
        public List<KvpDataDto> getKvpData()
        {
            KvpDataDtoRs kvpDataRs = new KvpDataDtoRs();
            return kvpDataRs.getData();
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
        [HttpGet]
        public List<DeliveryDataDto> getDeliveryData()
        {
            DeliveryDataDtoRs deliveryDataRs = new DeliveryDataDtoRs();
            return deliveryDataRs.getData();
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
    }
}

