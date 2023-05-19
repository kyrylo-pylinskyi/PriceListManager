using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Entities
{
    public interface IData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
    }
}
