using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Entities
{
    public class QuantityData : IData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
        public int? Quantity { get; set; }
        public int? Pack { get; set; }
        public string? Warehouse { get; set; }
    }
}
