using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Entities
{
    public class PriceData : IData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
        public decimal? Price { get; set; }
        public double? Discount { get; set; }
        public string? DiscountGroup { get; set; }
        public decimal? Deposit { get; set; }
        public string? DepositGroup { get; set; }
    }
}
