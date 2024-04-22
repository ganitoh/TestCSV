using CsvHelper.Configuration;
using TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem;

namespace TestCSV.Application.Services.Emplementation.CSVHapler
{
    public class PriceItemComamndMap : ClassMap<CreatePriceItemCommand>
    {
        public PriceItemComamndMap()
        {
            Map(i => i.Vendor).Name("Бренд");
            Map(i => i.Number).Name("Каталожный номер");
            Map(i => i.Description).Name("Описание");
            Map(i => i.Price).Name("Цена, руб.");
            Map(i => i.Count).Name("Наличие");

            Map(i => i.Count).TypeConverter<CustomInt32Converter>();
            Map(i => i.Price).TypeConverter<CustomDecimalConverter>();
        }
    }
}
