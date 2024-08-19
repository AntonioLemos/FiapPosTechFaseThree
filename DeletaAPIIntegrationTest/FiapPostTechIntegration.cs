using DeleteAPI.ViewModels;
using System.Net.Http.Json;

namespace DeletaAPIIntegrationTest
{
    public class Tests
    {
        [Test]
        public async Task FiapPosTechApi_DeletarContato()
        {
            // Arrange
            using var application = new FiapPostTechIntegrationTestFactory();
            var request = new ContatoViewModel
            {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000")
            };

            var client = application.CreateClient();

            // Act
            var response = await client.DeleteAsync($"/contato-delete-integration?id={request.Id}");
            response.EnsureSuccessStatusCode();

            // Assert
            var matchResponse = await response.Content.ReadFromJsonAsync<string>();
            var resultadoMessage = !string.IsNullOrEmpty(matchResponse) ? (matchResponse.Equals("Contato Deletado") ? "" : matchResponse) : "Erro ao deletar.";
            Assert.That(resultadoMessage, Is.EqualTo(string.Empty));
        }
    }
}