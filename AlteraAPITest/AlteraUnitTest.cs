using AlteraAPI.Business;
using AlteraAPI.Repository.Interface;
using AlteraAPI.ViewModels;
using Domain.Models;
using Moq;

namespace AlteraAPITest
{
    public class Tests
    {
        [Test]
        public async Task TestPutContato_DeveAtualizarContatoComSucesso()
        {
            // Arrange
            var contatoViewModel = new ContatoViewModel
            {
                Nome = "Fulano",
                Email = "fula@gemail.com",
                DDDSelecionado = 11,
                Telefone = "999988552",
                Id = Guid.NewGuid()
            };

            var ddd = new DDD { Codigo = 11 };

            var contatoRepositoryMock = new Mock<IContatoRepository>();
            var dddRepositoryMock = new Mock<IDDDRepository>();

            contatoRepositoryMock.Setup(repo => repo.GetByIdAsync(contatoViewModel.Id.Value))
                                 .ReturnsAsync(new CONTATO());

            dddRepositoryMock.Setup(repo => repo.GetDDDPorCodigo(contatoViewModel.DDDSelecionado))
                             .ReturnsAsync(ddd);

            contatoRepositoryMock.Setup(repo => repo.GetContatoPorEmail(contatoViewModel.Email))
                                 .ReturnsAsync((CONTATO)null);

            contatoRepositoryMock.Setup(repo => repo.GetListaContatoPorTelefone(contatoViewModel.Telefone))
                                 .ReturnsAsync(new List<CONTATO>());

            var contatoBusiness = new ContatoBusiness(contatoRepositoryMock.Object, dddRepositoryMock.Object);

            // Act
            var resultado = await contatoBusiness.PutContato(contatoViewModel);

            // Assert
            Assert.IsNotNull(resultado);
            var resultadoMessage = (resultado.Equals("Contato Editado") ? "" : resultado);
            Console.WriteLine($"Mensagem de retorno: {resultado}");
            Assert.IsTrue(string.IsNullOrEmpty(resultadoMessage));
        }

        [Test]
        public async Task TestPutContato_DeveApresentarErroDDDAtualizarContato()
        {
            // Arrange
            var contatoViewModel = new ContatoViewModel
            {
                Nome = "Fulano",
                Email = "fula@gemail.com",
                DDDSelecionado = 00,
                Telefone = "999988552",
                Id = Guid.NewGuid()
            };

            var ddd = new DDD { Codigo = 00 };

            var contatoRepositoryMock = new Mock<IContatoRepository>();
            var dddRepositoryMock = new Mock<IDDDRepository>();

            contatoRepositoryMock.Setup(repo => repo.GetByIdAsync(contatoViewModel.Id.Value))
                                 .ReturnsAsync(new CONTATO());

            dddRepositoryMock.Setup(repo => repo.GetDDDPorCodigo(contatoViewModel.DDDSelecionado))
                             .ReturnsAsync(ddd);

            contatoRepositoryMock.Setup(repo => repo.GetContatoPorEmail(contatoViewModel.Email))
                                 .ReturnsAsync((CONTATO)null);

            contatoRepositoryMock.Setup(repo => repo.GetListaContatoPorTelefone(contatoViewModel.Telefone))
                                 .ReturnsAsync(new List<CONTATO>());

            var contatoBusiness = new ContatoBusiness(contatoRepositoryMock.Object, dddRepositoryMock.Object);

            // Act
            var resultado = await contatoBusiness.PutContato(contatoViewModel);

            // Assert
            Assert.IsNotNull(resultado);
            var resultadoMessage = (resultado.Equals("Contato Editado") ? "" : resultado);
            Console.WriteLine($"Mensagem de retorno: {resultado}");
            Assert.IsTrue(!string.IsNullOrEmpty(resultadoMessage));
        }
    }
}