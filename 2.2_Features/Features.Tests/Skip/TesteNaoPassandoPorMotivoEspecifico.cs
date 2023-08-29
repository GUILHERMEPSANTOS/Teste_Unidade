﻿namespace Features.Tests.Skip
{
    public class TesteNaoPassandoPorMotivoEspecifico
    {
        [Fact(DisplayName = "Novo Cliente 2.0", Skip = "Nova versão 2.0 quebrando")]
        [Trait("Categoria", "Escapando dos Testes")] 
        public void Teste_NaoEstaPassando_VersaoNovaNaoCompativel()
        {
            Assert.True(false);
        }
    }
}
