using kpiMvcApi.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace kpiMvcApi.Controllers
{
    public class KpidataController : ApiController
    {
        [HttpGet]
        public List<ProductionDataDto> getProductionData()
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
    }
}

