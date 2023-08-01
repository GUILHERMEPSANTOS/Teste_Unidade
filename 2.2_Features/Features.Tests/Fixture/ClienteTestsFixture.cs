using Features.Clientes;

namespace Features.Tests.Fixture
{
    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            return new Cliente(
                   nome: "Guilheme",
                   sobrenome: "pereira",
                   email: "guilherme@hotmail.com",
                   dataCadastro: DateTime.UtcNow.AddYears(-3),
                   dataNascimento: DateTime.UtcNow.AddYears(-18),
                   ativo: true
               );
        }

        public Cliente GerarClienteInvalido()
        {
            return new Cliente(
                nome: "",
                sobrenome: "pereira",
                email: "guilherme@hotmail.com",
                dataCadastro: DateTime.UtcNow,
                dataNascimento: DateTime.UtcNow,
                ativo: true
            );
        }

        public void Dispose()
        {

        }
    }
}

