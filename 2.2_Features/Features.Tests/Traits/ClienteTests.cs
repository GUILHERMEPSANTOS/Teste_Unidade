using Features.Clientes;
using System.Data;

namespace Features.Tests.Traits
{
    public class ClienteTests
    {
        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveSerValido()
        {
            //Arrange
            var cliente = new Cliente(
                nome: "Guilheme",
                sobrenome: "pereira",
                email: "guilherme@hotmail.com",
                dataCadastro: DateTime.UtcNow.AddYears(-3),
                dataNascimento: DateTime.UtcNow.AddYears(-18),
                ativo: true
            );

            //Act
            var isValid = cliente.EhValido();

            //Assert
            Assert.True(isValid);
            Assert.Empty(cliente.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Novo Cliente Inálido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveSerInvalido()
        {
            //Arrange
            var cliente = new Cliente(
                nome: "",
                sobrenome: "pereira",
                email: "guilherme@hotmail.com",
                dataCadastro: DateTime.UtcNow,
                dataNascimento: DateTime.UtcNow,
                ativo: true
            );

            //Act
            var isValid = cliente.EhValido();

            //Assert
            Assert.False(isValid); 
            Assert.NotEmpty(cliente.ValidationResult.Errors);
        }
    }
}