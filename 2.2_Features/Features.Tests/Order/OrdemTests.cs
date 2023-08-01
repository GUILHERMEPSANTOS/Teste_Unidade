namespace Features.Tests.Order
{
    [TestCaseOrderer("Features.Tests.Order.PriorityOrderer", "Features.Tests")]
    public class OrdemTests
    {
        public static bool PrimeiroTesteChamado;
        public static bool SegundoTesteChamado;
        public static bool TerceiroTesteChamado;
        public static bool QuartoTesteChamado;

        [Fact(DisplayName = "Teste 1"), TestPriority(4)]
        [Trait("Categoria", "Ordenacao Testes")]
        public void PrimeiroTeste()
        {
            PrimeiroTesteChamado = true;

            Assert.True(SegundoTesteChamado);
            Assert.True(TerceiroTesteChamado);
            Assert.True(QuartoTesteChamado);
        }

        [Fact(DisplayName = "Teste 2"), TestPriority(3)]
        [Trait("Categoria", "Ordenacao Testes")]
        public void SegundoTeste()
        {
            SegundoTesteChamado= true;

            Assert.False(PrimeiroTesteChamado);
            Assert.True(TerceiroTesteChamado);
            Assert.True(QuartoTesteChamado);
        }

        [Fact(DisplayName = "Teste 3"), TestPriority(2)]
        [Trait("Categoria", "Ordenacao Testes")]
        public void TerceiroTeste()
        {
            TerceiroTesteChamado = true;
                
            Assert.False(PrimeiroTesteChamado);
            Assert.False(SegundoTesteChamado);
            Assert.True(QuartoTesteChamado);
        }

        [Fact(DisplayName = "Teste 4"), TestPriority(1)]
        [Trait("Categoria", "Ordenacao Testes")]
        public void QuartoTeste()
        {
            QuartoTesteChamado = true;

            Assert.False(PrimeiroTesteChamado);
            Assert.False(SegundoTesteChamado);
            Assert.False(TerceiroTesteChamado);
        }
    }
}
