using PriceListManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Extensions
{
    public static class QuantityExtension
    {
        public static IEnumerable<QuantityData> ToQuantity(this IEnumerable<string> source, char delimiter, Dictionary<string, int> columnNames)
        {
            foreach (var line in source)
            {
                var columns = line.Replace("\"", "").Split(delimiter);
                if (!(columns.Count() - 1 < columnNames.Values.Max()))
                    yield return new QuantityData
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
}
