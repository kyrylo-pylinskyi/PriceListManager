using PriceListManager.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Servicies
{
    public static class CsvWriter
    {
        public static void WriteAsCsvToLocal(this IEnumerable<ExportData> exportData, string outputFolder)
        {
            string supplierName = exportData.FirstOrDefault()?.DetailsData?.SupplierName ?? "UnnamedSupplier";
            string directory = $"{outputFolder}\\{supplierName}";
            Directory.CreateDirectory(directory);
            File.WriteAllText($"{directory}\\export.csv", ToCsv(exportData));
        }
        private static string ToCsv(IEnumerable<ExportData> exportData)
        {
            var csvBuilder = new StringBuilder();
            var properties = typeof(ExportRow).GetProperties();
            
            foreach ( var property in properties)
            {
                csvBuilder.Append(property.Name);
                csvBuilder.Append(";");
            }
            csvBuilder.AppendLine();

            foreach (var item in exportData)
            {
                var row = new ExportRow(item);
                foreach( var property in properties)
                {
                    var value = property.GetValue(row)?.ToString() ?? string.Empty;
                    csvBuilder.Append(value);
                    csvBuilder.Append(";");
                }
                csvBuilder.AppendLine();
            }
            return csvBuilder.ToString();
        }
    }
}
