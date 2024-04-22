using FluentValidation;

namespace TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem
{
    public class CreatePriceItemCommandValidation 
        : AbstractValidator<CreatePriceItemCommand>
    {
        public CreatePriceItemCommandValidation()
        {
            RuleFor(i => i.Price).NotEmpty().GreaterThan(0);
            RuleFor(i => i.SearchVendor).MaximumLength(64);
            RuleFor(i => i.SearchNumber).MaximumLength(64);
            RuleFor(i => i.Number).MaximumLength(64);
        }
    }
}
