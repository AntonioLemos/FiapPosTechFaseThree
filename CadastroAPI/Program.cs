using CadastroAPI.Business.Interface;
using CadastroAPI.Extensions;
using CadastroAPI.ViewModels;
using Data.DataContext;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Reflection;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client;
using System.Net.Http;


var builder = WebApplication.CreateBuilder(args);

var isCi = Environment.GetEnvironmentVariable("CI") == "true";

if (!isCi)
    builder.Services.AddOpenTelemetry()
      .WithMetrics(opt =>
          opt
              .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("cadastroapi"))
              .AddMeter(builder.Configuration.GetValue<string>("FIAPPOSTECHName"))
              .AddAspNetCoreInstrumentation()
              .AddHttpClientInstrumentation()
              .AddRuntimeInstrumentation()
              .AddProcessInstrumentation()
              .AddPrometheusExporter()
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

if (!isCi)
    await DatabaseInitializer.MigrateDatabaseAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "API CADASTRO!");


app.MapPost("/contato", async ([FromBody] ContatoViewModel contatoViewModel, IContatoBusiness contatoBusiness, HttpClient _httpClient) =>
{
    try
    {
        if (contatoViewModel == null)
        {
            return Results.BadRequest("O corpo da requisição n o pode estar vazio.");
        }

        MessageViewModel<ContatoViewModel> messageViewModel = new MessageViewModel<ContatoViewModel>()
        {
            NomeFila = "CadastroFila",
            Dados = contatoViewModel
        };

        var contato = JsonSerializer.Serialize(messageViewModel);
        var content = new StringContent(contato, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("http://productor:8080/contato", content);
        var responseBody = await response.Content.ReadAsStringAsync();

        if (responseBody.ToUpper().Contains("Ok".ToUpper()))
            return Results.Ok("Contato adicionado na fila.");

        return Results.Ok("Erro ao adicionar contato na fila.");
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("PostContato")
.WithOpenApi();

app.MapPost("/contato-integration", async ([FromBody] ContatoViewModel contatoViewModel, IContatoBusiness contatoBusiness) =>
{
    try
    {
        if (contatoViewModel == null)
        {
            return Results.BadRequest("O corpo da requisição n o pode estar vazio.");
        }
        var resultado = await contatoBusiness.PostContato(contatoViewModel);

        if (resultado != null)
        {
            return Results.Ok(resultado);
        }
        else
        {
            return Results.BadRequest("Falha ao processar o contato.");
        }
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("PostContatoIntegration")
.WithOpenApi();

app.Run();
