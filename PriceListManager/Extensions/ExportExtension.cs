using PriceListManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Extensions
{
    public static class ExportExtension
    {
        public static IEnumerable<ExportData> JoinOnSupplierPartNumber(this IEnumerable<IData> price, IEnumerable<IData> quantity, IEnumerable<IData> details)
        {
            return price.Join(quantity, p => p.SupplierPartNumber, q => q.SupplierPartNumber,
                                    (p, q) => new ExportData
                                    {
                                        SupplierPartNumber = p.SupplierPartNumber,
                                        PriceData = (PriceData)p,
                                        QuantityData = (QuantityData)q,
                                    }).Join(details, pq => pq.SupplierPartNumber, d => d.SupplierPartNumber, (pq, d) => new ExportData
                                    {
                                        SupplierPartNumber = pq.SupplierPartNumber,
                                        PartNumber = d.SupplierPartNumber,
                                        PriceData = pq.PriceData, 
                                        QuantityData = pq.QuantityData,
                                        DetailsData = (DetailsData)d,
                                    });
        }
    }
}
