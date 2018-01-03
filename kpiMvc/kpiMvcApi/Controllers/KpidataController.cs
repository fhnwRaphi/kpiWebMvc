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
    }
}

