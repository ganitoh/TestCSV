namespace TestCSV.Domain.Models
{
    public class PriceItem
    {
        public int Id { get; set; }
        public string Vendor { get; set; } = string.Empty; 
        public string Number { get; set; } = string.Empty;
        public string SearchVendor { get; set; } = string.Empty;
        public string SearchNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Count { get; set; }

    }
}
