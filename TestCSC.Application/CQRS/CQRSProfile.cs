using AutoMapper;
using TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem;
using TestCSV.Domain.Models;

namespace TestCSV.Application.CQRS
{
    public class CQRSProfile : Profile
    {
        public CQRSProfile()
        {
            CreateMap<CreatePriceItemCommand, PriceItem>();
        }
    }
}
