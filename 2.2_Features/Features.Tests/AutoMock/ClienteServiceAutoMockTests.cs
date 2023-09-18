using Features.Clientes;
using Features.Tests.Dados_Humanos;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.CodeDom.Compiler;
using Xunit.Abstractions;

namespace Features.Tests.AutoMock
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceAutoMockTests
    {
        private readonly ClienteTestsBogusFixture _clienteTestsBogusFixture;
     
        public ClienteServiceAutoMockTests(ClienteTestsBogusFixture clienteTestsBogusFixture)
        {
            _clienteTestsBogusFixture = clienteTestsBogusFixture;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteValido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>(); 
            //Act
            clienteService.Adicionar(cliente);

            //Assert
            Assert.True(cliente.EhValido());
            mocker.GetMock<IClienteRepository>().Verify(clienteRepo => clienteRepo.Adicionar(cliente), Times.Once);
            mocker.GetMock<IMediator>().Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar CLiente Com Falha")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoAClienteInvalido()
        {
            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteInvalido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();

            //Act
            clienteService.Adicionar(cliente);


            Assert.False(cliente.EhValido());
            mocker.GetMock<IClienteRepository>().Verify(clienteRepo => clienteRepo.Adicionar(cliente), Times.Never);
            mocker.GetMock<IMediator>().Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            //Arrange
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();
            var clientesMock = _clienteTestsBogusFixture.GerarClientesVariados();

            mocker.GetMock<IClienteRepository>().Setup(repository => repository.ObterTodos()).Returns(clientesMock);

            //Act
            var clientes = clienteService.ObterTodosAtivos();


            mocker.GetMock<IClienteRepository>().Verify(repository => repository.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.True(clientes.Count(cliente => !cliente.Ativo) == 0);
        }
    }
}
