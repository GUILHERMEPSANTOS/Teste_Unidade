﻿using Features.Clientes;

namespace Features.Tests.Fixture
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTestsInvalido
    {
        private readonly ClienteTestsFixture _clienteTestsFixture;

        public ClienteTestsInvalido(ClienteTestsFixture clienteTestsFixture)
        {
            _clienteTestsFixture = clienteTestsFixture;
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Fixture Testes")]
        public void Cliente_NovoCliente_DeveSerInvalido()
        {
            //Arrange
            var cliente = _clienteTestsFixture.GerarClienteInvalido();

            //Act
            var isValid = cliente.EhValido();

            //Assert
            Assert.False(isValid);
            Assert.NotEmpty(cliente.ValidationResult.Errors);
        }
    }
}
