using Features.Clientes;
using Features.Tests.Dados_Humanos;
using MediatR;
using Moq;

namespace Features.Tests.Mock
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceTests
    {
        private readonly ClienteTestsBogusFixture _clienteTestsBogusFixture;

        public ClienteServiceTests(ClienteTestsBogusFixture clienteTestsBogusFixture)
        {
            _clienteTestsBogusFixture = clienteTestsBogusFixture;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteValido();
            var clienteRepository = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();
            var clienteService = new ClienteService(clienteRepository.Object, mediator.Object);

            //Act
            clienteService.Adicionar(cliente);


            Assert.True(cliente.EhValido());
            clienteRepository.Verify(clienteRepo => clienteRepo.Adicionar(cliente), Times.Once);
            mediator.Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar CLiente Com Falha")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoAClienteInvalido()
        {
            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteInvalido();
            var clienteRepository = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();
            var clienteService = new ClienteService(clienteRepository.Object, mediator.Object);

            //Act
            clienteService.Adicionar(cliente);


            Assert.False(cliente.EhValido());
            clienteRepository.Verify(clienteRepo => clienteRepo.Adicionar(cliente), Times.Never);
            mediator.Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {   
            //Arrange
            var mediator = new Mock<IMediator>();
            var clienteRepositoy = new Mock<IClienteRepository>();
            var clienteService = new ClienteService(clienteRepositoy.Object, mediator.Object);
            var clientesMock = _clienteTestsBogusFixture.GerarClientesVariados();

            clienteRepositoy.Setup(repository => repository.ObterTodos()).Returns(clientesMock);

            //Act
            var clientes = clienteService.ObterTodosAtivos();


            clienteRepositoy.Verify(repository => repository.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.True(clientes.Count(cliente => !cliente.Ativo) == 0);
        }
    }
}
