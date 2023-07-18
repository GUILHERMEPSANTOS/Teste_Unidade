namespace Demo.Tests
{
    public class AssertingObjectTypesTests
    {
        [Fact]
        public void Funcionario_Criar_DeveRetornarTipoFuncionario()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Gui", 2500);

            // Assert
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact]
        public void Funcionario_Criar_DeveRetornarTipoDerivadoPessoa()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Gui", 2500);

            // Assert
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }
    }
}