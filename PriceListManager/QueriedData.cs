using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager
{
    public class QueriedData
    {
        public string? PartNumber { get; set; }
        public string? SupplierPartNumber { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public static List<QueriedData> JoinDataTables(List<PriceData> priceData, List<QuantityData> quantityData)
        {
            return priceData.Join(quantityData,
                                    p => p.SupplierPartNumber,
                                    q => q.SupplierPartNumber,
                                    (p, q) => new QueriedData
                                    {
                                        PartNumber = p.PartNumber,
                                        SupplierPartNumber = p.SupplierPartNumber,
                                        Price = p.Price,
                                        Quantity = q.Quantity
                                    }).ToList();
        }
    }
}
