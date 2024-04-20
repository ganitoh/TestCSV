using MediatR;
using TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem;
using TestCSV.Application.Services.Abstraction;
using TestCSV.Infrastructure.Services.EmailWork.Abstraction;

namespace TestCSV.Application.Services.Emplementation
{
    public class HomeService : IHomeService
    {
        private readonly ICsvHalperParser<CreatePriceItemCommand> _csvParser;
        private readonly IMediator _mediator;
        private readonly IEmailClient _emailClient;

        public HomeService(
            ICsvHalperParser<CreatePriceItemCommand> csvParser,
            IMediator mediator,
            IEmailClient emailClient)
        {
            _csvParser = csvParser;
            _mediator = mediator;
            _emailClient = emailClient;
        }

        public async Task CheckEmailAsync()
        {
            //получить данные из сообщения
            var filePath = await _emailClient.SaveFileFromemailAsync(@"C:\Users\vadik\source\repos\TestCSV\TestCSV.WebAPI\PriceItemsCsvFiles\");

            //распарсить их в список
            var dataPriceItems = _csvParser.Parse<PriceItemComamndMap>(filePath);

            // записать в бд
            foreach (var item in dataPriceItems)
                await _mediator.Send(item);
            
        }
    }
}
