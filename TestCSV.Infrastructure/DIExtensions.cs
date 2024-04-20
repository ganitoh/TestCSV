using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Serialization;
using TestCSV.Infrastructure.Services.EmailWork;
using TestCSV.Infrastructure.Services.EmailWork.Abstraction;
using TestCSV.Infrastructure.Services.EmailWork.Emplementation;
using TestCSV.Infrastructure.Services.Repositories.Abstracton;
using TestCSV.Infrastructure.Services.Repositories.Emplementation;

namespace TestCSV.Infrastructure
{
    public static class DIExtensions
    {
        private static void AddRepository(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ApplicationContext>(
                options=> options.UseNpgsql(connectionString));

            services.AddScoped<IPriceItemRepository, PriceItemRepository>();
        }

        public static void AddDbcontextPostgreSql(this IServiceCollection services,string connectionString)
        {
            services.AddRepository(connectionString);
        }

        public static void AddInfrastructureServices(this IServiceCollection services,MailOptions options)
        {
            var emailClientConstructor = typeof(EmailClient).GetConstructor(new Type[] { typeof(MailOptions) });
            if(emailClientConstructor is null)
                throw new ArgumentNullException(nameof(emailClientConstructor));

            services.AddScoped<IEmailClient,EmailClient>(provider 
                => (EmailClient)emailClientConstructor.Invoke(new[] {options}) );
        }

    }
}
