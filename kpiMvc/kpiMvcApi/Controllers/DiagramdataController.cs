using kpiMvcApi.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace kpiMvcApi.Controllers
{

    public class DiagramdataController : ApiController
    {
        [HttpGet]
        public IEnumerable<DiagramdataDto> Get(int? diagram )
        {
            try
            {
                return new DiagramdataDtoRepo().genRandomisedData(100); 
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
