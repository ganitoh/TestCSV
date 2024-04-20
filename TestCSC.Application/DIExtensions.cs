using Microsoft.Extensions.DependencyInjection;
using TestCSV.Application.CQRS;
using TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem;
using TestCSV.Application.Services.Abstraction;
using TestCSV.Application.Services.Emplementation;

namespace TestCSV.Application
{
    public static class DIExtensions
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(
                    typeof(CreatePriceItemCommand).Assembly,
                    typeof(CreatePriceItemComamndHandler).Assembly);

                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddAutoMapper(typeof(CQRSProfile));
            services.AddScoped<IHomeService,HomeService>();
            services.AddScoped(typeof(ICsvHalperParser<>),typeof(CsvHalperParser<>));
        }
    }
}
