using AutoMapper;
using MediatR;
using TestCSV.Domain.Models;
using TestCSV.Infrastructure.Services.Repositories.Abstracton;


namespace TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem
{
    public class CreatePriceItemCommandHandler 
        : IRequestHandler<CreatePriceItemCommand>
    {
        private readonly IPriceItemRepository _priceItemRepository;
        private readonly IMapper _mapper;

        public CreatePriceItemCommandHandler(
            IPriceItemRepository priceItemRepository,
            IMapper mapper)
        {
            _priceItemRepository = priceItemRepository;
            _mapper = mapper;
        }

        public async Task Handle(
            CreatePriceItemCommand request,
            CancellationToken cancellationToken)
        {
            var priceItem = _mapper.Map<PriceItem>(request);

            if (priceItem.Description.Length > 512)
                priceItem.Description = priceItem.Description.Substring(0, 512);

            priceItem.SearchVendor = new string(priceItem.Vendor.Where(char.IsLetterOrDigit).ToArray());
            priceItem.SearchNumber = new string(priceItem.Number.Where(char.IsLetterOrDigit).ToArray());

            await _priceItemRepository.CreateAsync(priceItem);
        }
    }
}
