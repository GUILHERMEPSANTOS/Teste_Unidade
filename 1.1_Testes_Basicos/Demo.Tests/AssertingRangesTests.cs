namespace Demo.Tests
{
    public class AssertingRangesTests
    {
        [Theory]
        [InlineData(500)]
        [InlineData(2500)]
        public void Funcionario_Salario_FaixasSalariaisDeveRespeitarNivelProfissional(double salario)
        {
            // Arrange & Act
            var funcionario = new Funcionario("Guilherme", salario);

            // Assert
            if (funcionario.NivelProfissional == NivelProfissional.Junior)
                Assert.InRange(funcionario.Salario, 500, 2500);

            if (funcionario.NivelProfissional == NivelProfissional.Pleno)
                Assert.InRange(funcionario.Salario, 2500, 8000);

            if (funcionario.NivelProfissional == NivelProfissional.Senior)
                Assert.InRange(funcionario.Salario, 8000, double.MaxValue);

            Assert.NotInRange(funcionario.Salario, 0, 499);
        }
    }
}