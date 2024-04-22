using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestCSV.Application.CQRS;
using TestCSV.Application.CQRS.PriceItems.Command.CreatePriceItem;
using TestCSV.Application.Services.Abstraction;
using TestCSV.Application.Services.Emplementation;
using TestCSV.Application.Services.Emplementation.CSVHapler;

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
                    typeof(CreatePriceItemCommandHandler).Assembly);

                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddScoped<IMediator, Mediator>();
            services.AddAutoMapper(typeof(CQRSProfile));
            services.AddScoped<IHomeService,HomeService>();
            services.AddScoped(typeof(ICsvHalperParser<>),typeof(CsvHalperParser<>));
        }
    }
}
