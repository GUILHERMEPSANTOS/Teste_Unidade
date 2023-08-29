using Features.Tests.AutoMock;
using FluentAssertions;

namespace Features.Tests.FluentAssertions
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteFluentAssertionsTests
    {
        private readonly ClienteTestsAutomockFixture _clienteTestsAutomockFixture;

        public ClienteFluentAssertionsTests(ClienteTestsAutomockFixture clienteTestsAutomockFixture)
        {
            _clienteTestsAutomockFixture = clienteTestsAutomockFixture;
        }

        [Fact]
        [Trait("Categoria", "Cliente Fluent Assertion Tests")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            //Arrange
            var cliente = _clienteTestsAutomockFixture.GerarClienteValido();

            //Act
            var resultado = cliente.EhValido();

            //Assert
            resultado.Should()
                .BeTrue();

            cliente.ValidationResult.Errors
                   .Should()
                   .HaveCount(0);
        }

        [Fact]
        [Trait("Categoria", "Cliente Fluent Assertion Tests")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            //Arrange
            var cliente = _clienteTestsAutomockFixture.GerarClienteInvalido();

            //Act
            var resultado = cliente.EhValido();

            //Assert
            resultado.Should()
                .BeFalse();

            cliente.ValidationResult.Errors
                .Should()
                .HaveCountGreaterThanOrEqualTo(1, "deve possuir errors de validação");             
        }
    }
}
