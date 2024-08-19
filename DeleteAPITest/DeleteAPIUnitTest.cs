using DeleteAPI.Business;
using DeleteAPI.Repository.Interface;
using DeleteAPI.ViewModels;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace DeleteAPITest
{
    public class Tests
    {
        [Test]
        public async Task TestDeleteContato_DeveExcluirContatoComSucesso()
        {
            // Arrange
            var contatoId = Guid.NewGuid();

            var contatoRepositoryMock = new Mock<IContatoRepository>();

            contatoRepositoryMock.Setup(repo => repo.GetByIdAsync(contatoId))
                                 .ReturnsAsync(new CONTATO());

            var contatoBusiness = new ContatoBusiness(contatoRepositoryMock.Object, It.IsAny<IDDDRepository>());

            // Act
            var resultado = await contatoBusiness.DeleteContato(new ContatoViewModel { Id = contatoId });

            // Assert
            Assert.IsNotNull(resultado);
            var resultadoMessage = (resultado.Equals("Contato Deletado") ? "" : resultado);
            Console.WriteLine($"Mensagem de retorno: {resultado}");
            Assert.IsTrue(string.IsNullOrEmpty(resultadoMessage));
        }
    }
}