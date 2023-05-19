using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Entities
{
    public class ExportData : IData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
        public PriceData? PriceData { get; set; }
        public QuantityData? QuantityData { get; set; }
        public DetailsData? DetailsData { get; set; }
    }
}
