using AutoMapper;
using MediatR;
using TestCSV.Domain.Models;
using TestCSV.Infrastructure.Services.Repositories.Abstracton;


namespace TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem
{
    public class CreatePriceItemComamndHandler 
        : IRequestHandler<CreatePriceItemCommand>
    {
        private readonly IPriceItemRepository _priceItemRepository;
        private readonly IMapper _mapper;

        public CreatePriceItemComamndHandler(
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
            await _priceItemRepository.CreateAsync(priceItem);
        }
    }
}
