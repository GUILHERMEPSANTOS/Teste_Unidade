using Features.Clientes;

namespace Features.Tests.Fixture
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTestsValido
    {
        private readonly ClienteTestsFixture _clienteTestsFixture;

        public ClienteTestsValido(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Fixture Testes")]
        public void Cliente_NovoCliente_DeveSerValido()
        {
            //Arrange
            var cliente = _clienteTestsFixture.GerarClienteValido();

            //Act
            var isValid = cliente.EhValido();

            //Assert
            Assert.True(isValid);
            Assert.Empty(cliente.ValidationResult.Errors);
        }
    }
}
