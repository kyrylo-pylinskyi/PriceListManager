using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PriceListManager;

namespace PriceListManager
{
    public class QuantityData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
        public int? Quantity { get; set; }
        public int? Pack { get; set; }
        public string? Warehouse { get; set; }

        internal static QuantityData ParseFromCsv(string row, char delimiter, Dictionary<string, int> columnNames)
        {
            var columns = row.Split(delimiter);
            return new QuantityData
            {
                PartNumber = columnNames.ContainsKey("PartNumber") ? columns[columnNames["PartNumber"]] : null,
                SupplierPartNumber = columnNames.ContainsKey("SupplierPartNumber") ? columns[columnNames["SupplierPartNumber"]] : null,
                Quantity = columnNames.ContainsKey("Quantity") ? int.Parse(columns[columnNames["Quantity"]].Replace(">", "").Trim()) : null,
                Pack = columnNames.ContainsKey("Pack") ? int.Parse(columns[columnNames["Pack"]].Replace(">", "").Trim()) : null,
                Warehouse = columnNames.ContainsKey("Warehouse") ? columns[columnNames["Warehouse"]] : null
            };
        }
    }
}
