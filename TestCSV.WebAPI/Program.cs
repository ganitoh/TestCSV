using TestCSV.Infrastructure.Services.EmailWork;
using TestCSV.Infrastructure;
using TestCSV.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(new MailOptions(
    builder.Configuration["MailService:Host"],
    builder.Configuration["MailService:Mail"],
    builder.Configuration["MailService:PasswordMail"],
    builder.Configuration["MailService:Port"]!));
builder.Services.AddApplicationService();
builder.Services.AddDbcontextPostgreSql(builder.Configuration["ConnectionStrings:PostgreSQl"]!);


var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
