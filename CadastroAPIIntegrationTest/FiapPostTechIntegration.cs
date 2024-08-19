using CadastroAPI.ViewModels;
using System.Net.Http.Json;

namespace CadastroAPIIntegrationTest
{
    public class Tests
    {
        [Test]
        public async Task FiapPosTechApi_AddContato()
        {
            // Arrange
            using var application = new FiapPostTechIntegrationTestFactory();
            var request = new ContatoViewModel
            {
                Nome = "João Silva Teste Adicionar",
                Telefone = "912345678",
                Email = "joao.silva@testeadd.com",
                DDDSelecionado = 35
            };

            var client = application.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/contato-integration", request);
            response.EnsureSuccessStatusCode();

            // Assert
            var matchResponse = await response.Content.ReadFromJsonAsync<string>();
            var resultadoMessage = !string.IsNullOrEmpty(matchResponse) ? (matchResponse.Equals("Contato Adicionado") ? "" : matchResponse) : "Erro ao adicionar.";
            Assert.That(resultadoMessage, Is.EqualTo(string.Empty));
        }
    }
}