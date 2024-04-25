using Cookbook.Api;
using Cookbook.Domain;
using Cookbook.Infrastructure;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddApiModule();

builder.Services.AddCookbookAuthentication(builder.Configuration);

builder.Services.AddDomainModule();
builder.Services.AddInfrastructureModule(builder.Configuration);

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var staticFilesPath = app.Configuration.GetSection("StaticFilesSettings:StaticFilesPath").Value;
var requestFilesPath = app.Configuration.GetSection("StaticFilesSettings:RequestPath").Value;
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesPath),
    RequestPath = new PathString(requestFilesPath)
});

app.UseHttpsRedirection();

app.Run();