using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Consumer.Eventos;

var builder = Host.CreateApplicationBuilder(args);

// Configure HttpClient
builder.Services.AddHttpClient();

// Configure Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var configuration = builder.Configuration;
var servidor = configuration.GetValue<string>("MassTransit:Servidor") ?? string.Empty;
var user = configuration.GetValue<string>("MassTransit:User") ?? string.Empty;
var password = configuration.GetValue<string>("MassTransit:Password") ?? string.Empty;

builder.Services.AddMassTransit(x =>
{

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(servidor, "/", h =>
        {
            h.Username(user);
            h.Password(password);
        });

        cfg.ReceiveEndpoint("CadastroFila", e =>
        {
            e.Consumer<CadastroAPIConsumidor>();
        });

        cfg.ReceiveEndpoint("AlteraFila", e =>
        {
            e.Consumer<AlteraAPIConsumidor>();
        });
        
        cfg.ReceiveEndpoint("DeletaFila", e =>
        {
            e.Consumer<DeleteAPIConsumidor>();
        });

        cfg.ConfigureEndpoints(context);
    });

    x.AddConsumer<CadastroAPIConsumidor>();
    x.AddConsumer<AlteraAPIConsumidor>();
    x.AddConsumer<DeleteAPIConsumidor>();
});

var host = builder.Build();
await host.RunAsync();