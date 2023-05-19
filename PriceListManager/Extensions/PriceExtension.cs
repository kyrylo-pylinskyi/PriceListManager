using PriceListManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Extensions
{
    public static class PriceExtension
    {
        public static IEnumerable<PriceData> ToPrice(this IEnumerable<string> source, char delimiter, Dictionary<string, int> columnNames)
        {
            foreach (var line in source)
            {
                var columns = line.Replace("\"", "").Split(delimiter);
                if (!(columns.Count() - 1 < columnNames.Values.Max()))
                    yield return new PriceData
                    {
                        PartNumber = columnNames.ContainsKey("PartNumber") ? columns[columnNames["PartNumber"]] : null,
                        SupplierPartNumber = columnNames.ContainsKey("SupplierPartNumber") ? columns[columnNames["SupplierPartNumber"]] : null,
                        Price = columnNames.ContainsKey("Price") ? decimal.Parse(columns[columnNames["Price"]].Replace(",", ".").Trim()) : null,
                        Discount = columnNames.ContainsKey("Discount") ? double.Parse(columns[columnNames["Discount"]].Replace(",", ".").Trim()) : null,
                        DiscountGroup = columnNames.ContainsKey("DiscountGroup") ? columns[columnNames["DiscountGroup"]] : null,
                        Deposit = columnNames.ContainsKey("Deposit") ? decimal.Parse(columns[columnNames["Deposit"]].Replace(",", ".").Trim()) : null,
                        DepositGroup = columnNames.ContainsKey("DepositGroup") ? columns[columnNames["DepositGroup"]] : null,
                    };
            }
        }
    }
}
