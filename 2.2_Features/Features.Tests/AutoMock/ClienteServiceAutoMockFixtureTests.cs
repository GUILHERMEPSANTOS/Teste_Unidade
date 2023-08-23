using Features.Clientes;
using Features.Tests.Dados_Humanos;
using MediatR;
using Moq;
using Moq.AutoMock;

namespace Features.Tests.AutoMock
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceAutoMockFixtureTests
    {
        private readonly ClienteTestsAutomockFixture _clienteTestsAutomockFixture;
        private readonly ClienteService _clienteService;

        public ClienteServiceAutoMockFixtureTests(ClienteTestsAutomockFixture clienteTestsAutomockFixture)
        {
            _clienteTestsAutomockFixture = clienteTestsAutomockFixture;
            _clienteService = clienteTestsAutomockFixture.ObterClienteService();
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsAutomockFixture.GerarClienteValido();
            var mocker = _clienteTestsAutomockFixture.Mocker;
            //Act
            _clienteService.Adicionar(cliente);

            //Assert
            Assert.True(cliente.EhValido());
            mocker.GetMock<IClienteRepository>().Verify(clienteRepo => clienteRepo.Adicionar(cliente), Times.Once);
            mocker.GetMock<IMediator>().Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar CLiente Com Falha")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoAClienteInvalido()
        {
            //Arrange
            var cliente = _clienteTestsAutomockFixture.GerarClienteInvalido();
            var mocker = _clienteTestsAutomockFixture.Mocker;

            //Act
            _clienteService.Adicionar(cliente);


            Assert.False(cliente.EhValido());
            mocker.GetMock<IClienteRepository>().Verify(clienteRepo => clienteRepo.Adicionar(cliente), Times.Never);
            mocker.GetMock<IMediator>().Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            //Arrange
            var mocker = _clienteTestsAutomockFixture.Mocker;
            var clientesMock = _clienteTestsAutomockFixture.GerarClientesVariados();

            mocker.GetMock<IClienteRepository>().Setup(repository => repository.ObterTodos()).Returns(clientesMock);

            //Act
            var clientes = _clienteService.ObterTodosAtivos();

            mocker.GetMock<IClienteRepository>().Verify(repository => repository.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.True(clientes.Count(cliente => !cliente.Ativo) == 0);
        }
    }
}
