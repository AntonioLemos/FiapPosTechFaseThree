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
    public class DeleteAPIConsumidor : IConsumer<MessageViewModel<ContatoViewModel>>
    {
        public async Task Consume(ConsumeContext<MessageViewModel<ContatoViewModel>> context)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                Console.WriteLine($"Received message: {context.Message.NomeFila}");

                var response = await _httpClient.DeleteAsync($"http://deletaapi:8080/contato-delete-integration?id={context.Message.Dados.Id}");
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
