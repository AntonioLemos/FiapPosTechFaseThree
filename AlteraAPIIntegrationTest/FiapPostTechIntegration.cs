using AlteraAPI.ViewModels;
using Domain.Models;
using System.Net.Http.Json;

namespace AlteraAPIIntegrationTest
{
    public class Tests
    {
        [Test]
        public async Task FiapPosTechApi_AlterarContato()
        {
            // Arrange
            using var application = new FiapPostTechIntegrationTestFactory();
            var request = new ContatoViewModel
            {
                Id = new Guid("550e8400-e29b-41d4-a716-446655440000"),
                Nome = "João Silva Teste Alterar",
                Telefone = "999977118",
                Email = "joao.silva@testealterar.com",
                DDDSelecionado = 11
            };

            var client = application.CreateClient();

            // Act
            var response = await client.PutAsJsonAsync("/contato-update-integration", request);
            response.EnsureSuccessStatusCode();

            // Assert
            var matchResponse = await response.Content.ReadFromJsonAsync<string>();
            var resultadoMessage = !string.IsNullOrEmpty(matchResponse) ? (matchResponse.Equals("Contato Editado") ? "" : matchResponse) : "Erro ao alterar.";
            Assert.That(resultadoMessage, Is.EqualTo(string.Empty));
        }
    }
}