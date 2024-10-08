using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProdutorAPI.ViewModels;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
var servidor = configuration.GetSection("MassTransit")["Servidor"] ?? string.Empty;
var user = configuration.GetSection("MassTransit")["User"] ?? string.Empty;
var password = configuration.GetSection("MassTransit")["Password"] ?? string.Empty;

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(servidor, "/", h =>
        {
            h.Username(user);
            h.Password(password);
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Produtor!");

app.MapPost("/contato", async ([FromBody] MessageViewModel<ContatoViewModel> contatoViewModel, IBus bus, IConfiguration configuration) =>
{
    try
    {
        var endPoint = await bus.GetSendEndpoint(new Uri($"queue:{contatoViewModel.NomeFila}"));

        await endPoint.Send(contatoViewModel);

        return Results.Ok("Productor contato Ok");
    }
    catch (Exception ex)
    {
        return Results.StatusCode(StatusCodes.Status500InternalServerError);
    }
})
.WithName("PostContato")
.WithOpenApi();



app.Run();

