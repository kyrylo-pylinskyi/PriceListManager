using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager
{
    public class PriceData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
        public decimal? Price { get; set; }
        public double? Discount { get; set; }
        public string? DiscountGroup { get; set; }
        public decimal? Deposit { get; set; }
        public string? DepositGroup { get; set; }

        internal static PriceData ParseFromCsv(string row, char delimiter, Dictionary<string, int> columnNames)
        {
            var columns = row.Split(delimiter);
            return new PriceData
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
