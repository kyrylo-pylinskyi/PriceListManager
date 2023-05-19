using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceListManager.Servicies
{
    public static class ArchiveManager
    {
        public static Dictionary<string, MemoryStream> UnzipFile(MemoryStream memoryStream)
        {
            Dictionary<string, MemoryStream> ArchiveFiles = new Dictionary<string, MemoryStream>();

            try
            {
                using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in zipArchive.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream extractedStream = new MemoryStream();
                            entryStream.CopyTo(extractedStream);
                            ArchiveFiles[entry.FullName] = extractedStream;

                            Console.WriteLine($"Extracted file: {entry.FullName}");
                        }
                    }
                }

                Console.WriteLine("Archive extracted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return ArchiveFiles;
        }
    }
}
