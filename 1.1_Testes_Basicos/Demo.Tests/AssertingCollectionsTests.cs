namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDeveTerHabilidadesVazias()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Gui", 10000);

            // Assert
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrEmpty(habilidade)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDeveTerHabilidadesBasicas()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Gui", 1100);

            // Assert
            Assert.Contains("OOP", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDeveTerHabilidadesAvancada()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Gui", 1100);

            // Assert
            Assert.DoesNotContain("Microservices", funcionario.Habilidades);
        }

        [Fact]
        public void Funcionario_Habilidades_SeniorDeveTerTodasHabilidades()
        {
            // Arrange & Act & Act
            var funcionario = FuncionarioFactory.Criar("Gui", 10000);
            var habilidades = new[] {
                "OOP",
                "Lógica de programação",
                "Testes",
                "Microservices"
            };

            // Assert
            Assert.Equal(habilidades, funcionario.Habilidades);
        }
    }
}