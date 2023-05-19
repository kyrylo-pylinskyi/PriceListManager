using Microsoft.VisualBasic.FileIO;
using PriceListManager.Entities;
using PriceListManager.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Servicies
{
    public static class CsvReader
    {
        public static IEnumerable<string> Parse(MemoryStream memoryStream,int skipRows)
        {
            List<string> lines = new List<string>();
            memoryStream.Seek(0, SeekOrigin.Begin);
            try
            {
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return lines.Skip(skipRows).Where(line => line.Length > 1);
        }

        public static IEnumerable<PriceData> AsPrice(this IEnumerable<string> csv, char delimiter, Dictionary<string, int> columnNames) => 
            csv.ToPrice(delimiter, columnNames);

        public static IEnumerable<QuantityData> AsQuantity(this IEnumerable<string> csv, char delimiter, Dictionary<string, int> columnNames) =>
            csv.ToQuantity(delimiter, columnNames);

        public static IEnumerable<DetailsData> AsDetails(this IEnumerable<string> csv, char delimiter, Dictionary<string, int> columnNames, string supplierName, Currencies currency) =>
            csv.ToDetails(delimiter, columnNames, supplierName, currency);
    }
}
