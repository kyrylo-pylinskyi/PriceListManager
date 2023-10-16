using PriceListManager.Entities;
using PriceListManager.Extensions;
using PriceListManager.Servicies;
using System.Linq;

var start = DateTime.Now;

FtpConnection connection = new FtpConnection("128.0.0.1", "suppliers", "password", "mysupplier", "price_quantity.zip");

MemoryStream memoryStream = connection.DownloadFile();

var archive = ArchiveManager.UnzipFile(memoryStream);

var quantityColumns = new Dictionary<string, int>()
{
    { "SupplierPartNumber", 0 },
    { "Quantity", 1 },
    { "Warehouse", 2 }
};

var quantity = CsvReader.Parse(archive["Quantity.csv"], 0).AsQuantity(';', quantityColumns);

var priceColumns = new Dictionary<string, int>()
{
    { "SupplierPartNumber", 0 },
    { "Price", 1 },
};

var price = CsvReader.Parse(archive["PriceList.csv"], 1).AsPrice(';', priceColumns);

connection = new FtpConnection("128.0.0.1", "suppliers", "password", "mysupplier", "mysupplier", "details.zip");

memoryStream = connection.DownloadFile();
archive = ArchiveManager.UnzipFile(memoryStream);

var detailsColumns = new Dictionary<string, int>()
{
    { "SupplierPartNumber", 0 },
    { "Manufacturer", 2},
    { "PartNumber", 3 },
    { "PartName", 4},
    { "PartDescription", 5}
};

var details = CsvReader.Parse(archive["details.csv"], 1).AsDetails(';', detailsColumns, "MySupplier", Currencies.PLN);

var joined = price.JoinOnSupplierPartNumber(quantity, details);

foreach (var row in joined.Take(10))
{
    Console.WriteLine($"{row.SupplierPartNumber}\t{row.PartNumber}\t{row.PriceData.Price}\t{row.QuantityData.Quantity}");
}

var end = DateTime.Now;

joined.WriteAsCsvToLocal(@"C:\personal");

Console.WriteLine($"Operation time : {end - start }");
