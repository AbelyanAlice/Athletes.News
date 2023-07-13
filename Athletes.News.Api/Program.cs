using Athletes.News.Infrastructure;
using Athletes.News.Services;
using Athletes.News.Core.Infrastructures.DependencyInjection;
using Serilog;
using Athletes.News.Api.Installer;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using Athletes.News.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration));
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Services.AddControllers().AddJsonOptions(x =>
{
x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddHttpClient();
builder.Services.RegisterAllDependencies();
builder.Services.AddInFrastructure(builder.Configuration);
builder.Services.AddServices();
// Add services to the container.
builder.Services.InstallServicesInAssembly(builder.Configuration, builder.Environment);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
try
{
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
app.UseSwagger();
app.UseSwaggerUI(options => options.DocExpansion(DocExpansion.None));
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.SeedAsync(app.Services).Run();
}
catch (Exception e)
{
Log.Fatal(e,"ErrorStart");
}
finally
{
Log.CloseAndFlush();
}
