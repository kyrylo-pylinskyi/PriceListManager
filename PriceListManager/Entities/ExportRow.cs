using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Entities
{
    public class ExportRow
    {
        public string SupplierName { get; set; }
        public string SupplierPartNumber { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string PartDescription { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Warehouse { get; set; }
        public ExportRow(ExportData exportData)
        {
            SupplierName = exportData.DetailsData.SupplierName ?? string.Empty;
            SupplierPartNumber = exportData.SupplierPartNumber ?? string.Empty;
            PartNumber = exportData.PartNumber ?? string.Empty;
            PartName = exportData.DetailsData.PartName ?? string.Empty;
            PartDescription = exportData.DetailsData.PartDescription ?? string.Empty;
            Manufacturer = exportData.DetailsData.Manufacturer ?? string.Empty;
            Price = exportData.PriceData.Price ?? 0;
            Quantity = exportData.QuantityData.Quantity ?? 0;
            Warehouse = exportData.QuantityData.Warehouse ?? string.Empty;
        }
    }
}
