using Features.Clientes;
using Features.Tests.AutoMock;
using FluentAssertions;
using FluentAssertions.Extensions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Tests.FluentAssertions
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceFluentAssertionsTests
    {
        private readonly ClienteTestsAutomockFixture _clienteTestsAutomockFixture;

        public ClienteServiceFluentAssertionsTests(ClienteTestsAutomockFixture clienteTestsAutomockFixture)
        {
            _clienteTestsAutomockFixture = clienteTestsAutomockFixture;
        }

        [Fact]
        [Trait("Categoria", "ClienteService Fluent Assertions Tests")]
        public void ClienteService_AdicionarCliente_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsAutomockFixture.GerarClienteValido();
            var clienteService = _clienteTestsAutomockFixture.ObterClienteService();
            var mocker = _clienteTestsAutomockFixture.Mocker;

            //Act
            clienteService.Adicionar(cliente);

            //Assert 
            cliente.EhValido().Should().BeTrue();
            mocker.GetMock<IClienteRepository>().Verify(repository => repository.Adicionar(cliente), Times.Once);
            mocker.GetMock<IMediator>().Verify(mediator => mediator.Publish(It.IsAny<INotification>(),CancellationToken.None), Times.Once);
        }


        [Fact]
        [Trait("Categoria", "ClienteService Fluent Assertions Tests")]
        public void ClienteService_AdicionarCliente_DeveExecutarComFalha()
        {
            //Arrange
            var cliente = _clienteTestsAutomockFixture.GerarClienteInvalido();
            var clienteService = _clienteTestsAutomockFixture.ObterClienteService();
            var mocker = _clienteTestsAutomockFixture.Mocker;

            //Act
            clienteService.Adicionar(cliente);

            //Assert 
            cliente.EhValido().Should().BeFalse();
            mocker.GetMock<IClienteRepository>().Verify(repository => repository.Adicionar(cliente), Times.Never);
            mocker.GetMock<IMediator>().Verify(mediator => mediator.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);

            clienteService.ExecutionTimeOf(clienteService => clienteService.ObterTodosAtivos())
                   .Should()
                   .BeLessThan(500.Milliseconds());
        }
    }
}
