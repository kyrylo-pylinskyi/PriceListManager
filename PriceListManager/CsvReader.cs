using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager
{
    public static class CsvReader
    {
        public static List<QuantityData> ParseQuantity(MemoryStream memoryStream, char delimiter, int skipRows, Dictionary<string, int> columnNames) 
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

            return lines.Skip(skipRows)
                         .Where(line => line.Length > 1)
                         .Select(line => QuantityData.ParseFromCsv(line.Replace("\"", ""), delimiter, columnNames)).ToList();
        }

        public static List<PriceData> ParsePrice(MemoryStream memoryStream, char delimiter, int skipRows, Dictionary<string, int> columnNames)
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

            return lines.Skip(skipRows)
                         .Where(line => line.Length > 1)
                         .Select(line => PriceData.ParseFromCsv(line.Replace("\"", ""), delimiter, columnNames)).ToList();
        }
    }
}
