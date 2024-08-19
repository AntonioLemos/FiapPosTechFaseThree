using CadastroAPI.Business;
using CadastroAPI.Business.Interface;
using CadastroAPI.Repository.Interface;
using CadastroAPI.ViewModels;
using Domain.Models;
using Moq;

namespace CadastroAPITest
{
    public class Tests
    {
        [Test]
        public async Task TestPostContato_DeveAdicionarContatoComSucesso()
        {
            // Arrange
            var contatoViewModel = new ContatoViewModel
            {
                Nome = "Fulano",
                Email = "fula@gemail.com",
                DDDSelecionado = 11,
                Telefone = "999988552"
            };

            var ddd = new DDD { Codigo = 11 };

            var contatoRepositoryMock = new Mock<IContatoRepository>();
            var dddRepositoryMock = new Mock<IDDDRepository>();

            dddRepositoryMock.Setup(repo => repo.GetDDDPorCodigo(contatoViewModel.DDDSelecionado))
                             .ReturnsAsync(ddd);

            contatoRepositoryMock.Setup(repo => repo.GetContatoPorEmail(contatoViewModel.Email))
                                 .ReturnsAsync((CONTATO)null);

            contatoRepositoryMock.Setup(repo => repo.GetListaContatoPorTelefone(contatoViewModel.Telefone))
                                 .ReturnsAsync(new List<CONTATO>());

            var contatoBusiness = new ContatoBusiness(contatoRepositoryMock.Object, dddRepositoryMock.Object);

            // Act
            var resultado = await contatoBusiness.PostContato(contatoViewModel);

            // Assert
            Assert.IsNotNull(resultado);
            var resultadoMessage = (resultado.Equals("Contato Adicionado") ? "" : resultado);
            Console.WriteLine($"Mensagem de retorno: {resultado}");
            Assert.IsTrue(string.IsNullOrEmpty(resultadoMessage));
        }

        [Test]
        public async Task TestPostContato_DeveApresentarErroEmailAdicionarContato()
        {
            // Arrange
            var contatoViewModel = new ContatoViewModel
            {
                Nome = "Fulano",
                Email = "fum",
                DDDSelecionado = 11,
                Telefone = "999988552"
            };

            var ddd = new DDD { Codigo = 11 };

            var contatoRepositoryMock = new Mock<IContatoRepository>();
            var dddRepositoryMock = new Mock<IDDDRepository>();

            dddRepositoryMock.Setup(repo => repo.GetDDDPorCodigo(contatoViewModel.DDDSelecionado))
                             .ReturnsAsync(ddd);

            contatoRepositoryMock.Setup(repo => repo.GetContatoPorEmail(contatoViewModel.Email))
                                 .ReturnsAsync((CONTATO)null);

            contatoRepositoryMock.Setup(repo => repo.GetListaContatoPorTelefone(contatoViewModel.Telefone))
                                 .ReturnsAsync(new List<CONTATO>());

            var contatoBusiness = new ContatoBusiness(contatoRepositoryMock.Object, dddRepositoryMock.Object);

            // Act
            var resultado = await contatoBusiness.PostContato(contatoViewModel);

            // Assert
            Assert.IsNotNull(resultado);
            var resultadoMessage = (resultado.Equals("Contato Adicionado") ? "" : resultado);
            Console.WriteLine($"Mensagem de retorno: {resultado}");
            Assert.IsTrue(!string.IsNullOrEmpty(resultadoMessage));
        }

    }
}