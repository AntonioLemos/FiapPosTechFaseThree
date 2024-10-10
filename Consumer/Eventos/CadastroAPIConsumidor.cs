using MassTransit;
using ProdutorAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consumer.Eventos
{
    public class CadastroAPIConsumidor : IConsumer<MessageViewModel<ContatoViewModel>>
    {
        public async Task Consume(ConsumeContext<MessageViewModel<ContatoViewModel>> context)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                Console.WriteLine($"Received message: {context.Message.NomeFila}");
                //var contatoDes = JsonSerializer.Deserialize<ContatoViewModel>(message);
                var contato = JsonSerializer.Serialize(context.Message.Dados);
                var content = new StringContent(contato, Encoding.UTF8, "application/json");


                var response = await _httpClient.PostAsync("http://cadastroapi:8080/contato-integration", content);
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody ?? "Dados não encontrados");
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message: {ex.Message}");
                throw;
            }
        }
    }
}
