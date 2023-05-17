using PriceListManager;
using System.Linq;

var start = DateTime.Now;

FtpConnection connection = new FtpConnection("123.456.789.012", "user", "password", "folder/subfolder", "archive.zip");

MemoryStream memoryStream = connection.DownloadFile();

var archive = ArchiveManager.UnzipFile(memoryStream);

var quantityColumns = new Dictionary<string, int>()
{
    { "SupplierPartNumber", 0 },
    { "Quantity", 1 },
    { "Warehouse", 2 }
};

var priceColumns = new Dictionary<string, int>()
{
    { "SupplierPartNumber", 0 },
    { "Price", 1 },
};



var quantity = CsvReader.ParseQuantity(archive["Quantity.csv"], ';', 0, quantityColumns);
var price = CsvReader.ParsePrice(archive["PriceList.csv"], ';', 1, priceColumns);

var joined = QueriedData.JoinDataTables(price, quantity);

foreach (var row in joined.Take(10))
{
    Console.WriteLine($"{row.SupplierPartNumber}\t{row.PartNumber}\t{row.Price}\t{row.Quantity}");
}

var end = DateTime.Now;

Console.WriteLine($"Operation time : {end - start }");
