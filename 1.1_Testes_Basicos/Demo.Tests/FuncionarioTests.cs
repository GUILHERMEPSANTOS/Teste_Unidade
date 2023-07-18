namespace Demo.Tests
{
    public class FuncionarioTests
    {
        [Fact]
        public void Funcionario_Nome_NaoPodeSerNullOuVazio()
        {
            //Arrange & Act
            var funcionario = new Funcionario("", 600);

            //Assert
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact]
        public void Funcionario_Nome_NaoDeveTerApelido()
        {
            //Arrange & Act
            var funcionario = new Funcionario("Gui", 5000);

            //Assert
            Assert.Null(funcionario.Apelido);

            //Assert bool
            Assert.False(funcionario.Apelido?.Length > 0);
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
        }
    }
}