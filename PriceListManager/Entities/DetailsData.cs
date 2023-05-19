using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Entities
{
    public class DetailsData : IData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
        public string? SupplierName { get; set; }
        public string? Manufacturer { get; set; }
        public string? PartName { get; set; }
        public string? PartDescription { get; set; }
        public Currencies Currency { get; set; }
    }
}
