using Data.DataContext;
using DeleteAPI.Business.Interface;
using DeleteAPI.Extensions;
using DeleteAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using System.Reflection;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var isCi = Environment.GetEnvironmentVariable("CI") == "true";

if (!isCi)
    builder.Services.AddOpenTelemetry()
      .WithMetrics(opt =>
          opt
              .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("deleteapi"))
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

await DatabaseInitializer.MigrateDatabaseAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "API Deleta!");

app.MapDelete("/contato-delete", async ([FromBody] ContatoViewModel contatoViewModel, IContatoBusiness contatoBusiness, HttpClient _httpClient) =>
{
    try
    {
        if (contatoViewModel == null)
        {
            return Results.BadRequest("O corpo da requisi��o n o pode estar vazio.");
        }

        MessageViewModel<ContatoViewModel> messageViewModel = new MessageViewModel<ContatoViewModel>()
        {
            NomeFila = "DeletaFila",
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
.WithName("DeleteContato")
.WithOpenApi();

app.MapDelete("/contato-delete-integration", async (Guid id, IContatoBusiness contatoBusiness) =>
{
    try
    {
        var resultado = await contatoBusiness.DeleteContato(new ContatoViewModel() { Id = id });

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
.WithName("DeleteContatoIntegration")
.WithOpenApi();

app.Run();


