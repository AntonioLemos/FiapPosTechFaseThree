using ConsultaAPI.Business.Interface;
using ConsultaAPI.Extensions;
using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var isCi = Environment.GetEnvironmentVariable("CI") == "true";

if (!isCi)
    builder.Services.AddOpenTelemetry()
      .WithMetrics(opt =>
          opt
              .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("consultaapi"))
              .AddMeter(builder.Configuration.GetValue<string>("FIAPPOSTECHName"))
              .AddAspNetCoreInstrumentation()
              .AddHttpClientInstrumentation()
              .AddRuntimeInstrumentation()
              .AddProcessInstrumentation()
              .AddOtlpExporter(opts =>
              {
                  opts.Endpoint = new Uri(builder.Configuration["Otel:Endpoint"]);
              })
      );

builder.Services.AddDbContext<FiapDataContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

builder.Services.AddGenericServices(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

var app = builder.Build();

await app.MigrateDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "API CONSULTA!");

app.MapGet("/contatospaginado", async (int currentPage, int pageSize, IContatoBusiness contatoBusiness, int ddd = 0) =>
{
    try
    {
        var resultado = await contatoBusiness.GetContatosPaginados(currentPage, pageSize, ddd);

        if (resultado != null)
        {
            return Results.Ok(resultado);
        }
        else
        {
            return Results.BadRequest("Falha ao buscar contatos.");
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("GetContatos")
.WithOpenApi();

app.Run();
