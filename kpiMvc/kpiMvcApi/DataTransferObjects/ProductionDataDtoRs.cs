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
        public string getDataset()
        {
            return "[12, 19, 3, 5, 2, 3]";
        }
        public string getChartLabels()
        {
            return "['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange']";
        }
        public string getDatasetLabel()
        {
            return "'Chart Label'";
        }
        public string getDatsetBackroundColor()
        {
            return  "['rgba(255, 99, 132, 0.2)','rgba(54, 162, 235, 0.2)','rgba(255, 206, 86, 0.2)','rgba(75, 192, 192, 0.2)','rgba(153, 102, 255, 0.2)','rgba(255, 159, 64, 0.2)']";
        }
        public string getChartTitle()
        {
            return "'Production Data'";
        }
        public int getChartBorderWidth()
        {
            return 2;
        }
        public string getChartHeigh()
        {
            return "400";
        }
        public string getChartWidth()
        {
            return "600";
        }
    }
}
