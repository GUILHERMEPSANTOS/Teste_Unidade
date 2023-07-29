using Features.Clientes;

namespace Features.Tests.Fixture
{
    [Collection(nameof(ClienteCollectionremoção))]
    public class ClienteTestsInvalido
    {
        private readonly ClienteTestsFixture _clienteTestsFixture;

        public ClienteTestsInvalido(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }

        [Fact(DisplayName = "Novo Cliente Inálido")]
        [Trait("Categoria", "Cliente Fixture Testes")]
        public void Cliente_NovoCliente_DeveSerInvalido()
        {
            //Arrange
            var cliente = _clienteTestsFixture.GerarClienteInvlaido();

            //Act
            var isValid = cliente.EhValido();

            //Assert
            Assert.False(isValid);
            Assert.NotEmpty(cliente.ValidationResult.Errors);
        }
    }
}
