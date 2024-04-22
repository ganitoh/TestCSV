using MediatR;
using TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem;
using TestCSV.Application.Services.Abstraction;
using TestCSV.Application.Services.Emplementation.CSVHapler;
using TestCSV.Infrastructure.Services.EmailWork.Abstraction;

namespace TestCSV.Application.Services.Emplementation
{
    public class HomeService : IHomeService
    {
        private readonly ICsvHalperParser<CreatePriceItemCommand> _csvParser;
        private readonly IEmailClient _emailClient;

        public HomeService(
            ICsvHalperParser<CreatePriceItemCommand> csvParser,
            IEmailClient emailClient)
        {
            _csvParser = csvParser;
            _emailClient = emailClient;
        }

        public async Task CheckEmailAsync()
        {
            var filePath = await _emailClient.SaveFileFromemailAsync(@"C:\Users\vadik\source\repos\TestCSV\TestCSV.WebAPI\PriceItemsCsvFiles\");

            await _csvParser.ParseAndSaveAsync<PriceItemComamndMap>(filePath);            
        }
    }
}
