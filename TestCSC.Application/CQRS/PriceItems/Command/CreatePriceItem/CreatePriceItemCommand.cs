using CsvHelper.Configuration.Attributes;
using MediatR;
using TestCSV.Application.Services.Emplementation;

namespace TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem
{
    public class CreatePriceItemCommand : IRequest
    {
        public string Vendor { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string SearchVendor { get; set; } = string.Empty;
        public string SearchNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Count { get; set; }

        public CreatePriceItemCommand() { }

        public CreatePriceItemCommand(string vendor, string number, string searchVendor, string searchNumber, string description, decimal price, int count)
        {
            Vendor = vendor;
            Number = number;
            SearchVendor = searchVendor;
            SearchNumber = searchNumber;
            Description = description;
            Price = price;
            Count = count;
        }
    }
}
