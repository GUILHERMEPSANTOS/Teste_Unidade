namespace Demo.Tests
{
    public class StringToolsTests
    {
        [Fact]
        public void StringTools_Unir_RetornarNomeCompleto()
        {
            // Arrange 
            var stringTools = new StringTools();

            //Act
            var nomeCompleto = stringTools.Unir("Guilherme", "Pereira");

            //Assert
            Assert.Equal("Guilherme Pereira", nomeCompleto);
        }

        [Fact]
        public void StringTools_Unir_DeveIgnorarCase()
        {
            //Arrange
            var stringTools = new StringTools();

            //Act
            var nomeCompleto = stringTools.Unir("GUILHERME", "PEREIRA");

            //Assert
            Assert.Equal("Guilherme Pereira", nomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void StringTools_Unir_DeveConterTrecho()
        {
            //Arrange
            var stringTools = new StringTools();

            //Act
            var nomeCompleto = stringTools.Unir("Guilherme", "Pereira");

            //Assert
            Assert.Contains("herme", nomeCompleto);
        }

        [Fact]
        public void StringTools_Unir_DeveComecarCom()
        {
            //Arrange
            var stringTools = new StringTools();

            //Act
            var nomeCompleto = stringTools.Unir("Guilherme", "Pereira");

            //Assert
            Assert.StartsWith("Gui", nomeCompleto);
        }

        [Fact]
        public void StringTools_Unir_DeveFinalizarCom()
        {
            //Arrange
            var stringTools = new StringTools();

            //Act
            var nomeCompleto = stringTools.Unir("Guilherme", "Pereira");

            //Assert
            Assert.EndsWith("ira", nomeCompleto);
        }

        [Fact]
        public void StringTools_Unir_ValidarExpressaoRegular()
        {
            //Arrange
            var stringTools = new StringTools();

            //Act
            var nomeCompleto = stringTools.Unir("Guilherme", "Pereira");

            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }
    }
}