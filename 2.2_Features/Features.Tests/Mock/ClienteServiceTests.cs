using Features.Clientes;
using Features.Tests.Dados_Humanos;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public 
    }
}
