using Microsoft.OpenApi.Models;
using Pnipa.Geosnipa.Api;
using Pnipa.Geosnipa.Aplicacion;
using Pnipa.Geosnipa.Infraestructura.MongoDb;
using Pnipa.Geosnipa.Infraestructura.SqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureSqlServerLayer(builder.Configuration);
builder.Services.AddInfrastructureMongoDbLayer();

builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Pnipa.Geosnipa.Api", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();