using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kpiMvcApi.DataTransferObjects
{
    public class ProductionDataDtoRs
    {
        public List<ProductionDataDto> ProductionDataRs { get; set; }
        public ProductionDataDtoRs()
        {
            this.ProductionDataRs = new List<ProductionDataDto>();
        }
        public List<ProductionDataDto> getData()
        {
            DateTime startdate = new DateTime(2018, 1, 1);
            DateTime stopdate = DateTime.Now;

            var model = new Models.kpidbEntities1();
            var rs = model.ePcbDailies.Where(x => x.productionDay >= startdate && x.productionDay <= stopdate);

            foreach (var r in rs)
            {
                ProductionDataDto pddto = new ProductionDataDto()
                {
                    ProductionDay = r.productionDay,
                    PcbQuantity = r.pcbQuantity,
                    PcbSumPrice = r.pcbSumPrice,
                    PcbGenerationId = r.pcbGenerationId,
                    PcbClassId = r.pcbClassId
                };
                this.ProductionDataRs.Add(pddto);
            }
            return this.ProductionDataRs;
        }
        public bool setData(List<ProductionDataDto> ppdto)
        {
            Models.kpidbEntities1 model = new Models.kpidbEntities1();
            foreach (var dto in ppdto)
            {
                Models.ePcbDaily mdl = new Models.ePcbDaily();
                mdl.pcbGenerationId = dto.PcbGenerationId;
                mdl.pcbClassId = dto.PcbClassId;
                mdl.pcbQuantity = dto.PcbQuantity;
                mdl.pcbSumPrice = dto.PcbSumPrice;
                mdl.productionDay = dto.ProductionDay;
                model.ePcbDailies.Add(mdl);
            }
            model.SaveChanges();
            return true;
        }
    }
}
