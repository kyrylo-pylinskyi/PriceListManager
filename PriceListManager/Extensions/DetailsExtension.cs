using PriceListManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Extensions
{
    public static class DetailsExtension
    {
        public static IEnumerable<DetailsData> ToDetails(this IEnumerable<string> source, char delimiter, Dictionary<string, int> columnNames, string supplierName, Currencies currency)
        {
            foreach (var line in source)
            {
                var columns = line.Replace("\"", "").Split(delimiter);
                if(!(columns.Count() - 1 < columnNames.Values.Max()))
                    yield return new DetailsData
                    {
                        PartNumber = columnNames.ContainsKey("PartNumber") ? columns[columnNames["PartNumber"]] : null,
                        SupplierPartNumber = columnNames.ContainsKey("SupplierPartNumber") ? columns[columnNames["SupplierPartNumber"]] : null,
                        SupplierName = supplierName,
                        Manufacturer = columnNames.ContainsKey("Manufacturer") ? columns[columnNames["Manufacturer"]] : null,
                        PartName = columnNames.ContainsKey("PartName") ? columns[columnNames["PartName"]] : null,
                        PartDescription = columnNames.ContainsKey("PartDescription") ? columns[columnNames["PartDescription"]] : null,
                        Currency = currency
                    };
            }
        }
    }
}
