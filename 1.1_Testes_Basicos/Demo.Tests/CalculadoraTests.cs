namespace Demo.Tests;

public class CalculadoraTests
{
    [Fact]
    public void Calculadora_Somar_RetornarValorSoma()
    {
        //Arrange 
        var calculadora = new Calculadora();

        //Act
        var resultado = calculadora.Somar(2, 2);

        //Assert
        Assert.Equal(4, resultado);
    }

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(2, 3, 5)]
    [InlineData(2, 4, 6)]
    [InlineData(2, 5, 7)]
    public void Calculadora_Somar_RetornarValorSomaCorretos(double primeiroNumero, double segundoNumero, double total)
    {
        //Arrange
        var calculadora = new Calculadora();

        //Act
        var resultado = calculadora.Somar(primeiroNumero, segundoNumero);

        //Assert
        Assert.Equal(total, resultado);
    }

    [Fact]
    public void Calculadora_Somar_NaoDeveSerIgual()
    {
        //Arrange
        var calculadora = new Calculadora();

        //Act
        var resultado = calculadora.Somar(1.9, 1.299999999999998);

        //Assert
        Assert.NotEqual(3.3, resultado);
    }
}
