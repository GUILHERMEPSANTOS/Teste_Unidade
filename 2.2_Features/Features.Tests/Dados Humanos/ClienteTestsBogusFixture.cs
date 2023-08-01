
using Bogus;
using Features.Clientes;
using static Bogus.DataSets.Name;

namespace Features.Tests.Dados_Humanos
{
    public class ClienteTestsBogusFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var genero = new Faker().PickRandom<Gender>();

            var clienteFaker = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(faker => new Cliente(
                        nome: faker.Name.FirstName(genero),
                        sobrenome: faker.Name.LastName(genero),
                        email: "",
                        dataNascimento: faker.Date.Past(80, DateTime.UtcNow.AddYears(-18)),
                        dataCadastro: faker.Date.Past(3),
                        true
                  )).RuleFor(cliente => cliente.Email,
                            (faker, cliente) => faker.Internet.Email(cliente.Nome.ToLower(), cliente.Sobrenome.ToLower()));

            return clienteFaker;
        }

        public Cliente GerarClienteInvlaido()
        {
            var genero = new Faker().PickRandom<Gender>();

            var clienteFaker = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(faker => new Cliente(
                        nome: faker.Name.FirstName(genero),
                        sobrenome: faker.Name.LastName(genero),
                        email: "",
                        dataNascimento: faker.Date.Past(80, DateTime.UtcNow.AddYears(-1)),
                        dataCadastro: DateTime.UtcNow,
                        ativo: false
                  ));

            return clienteFaker;
        }

        public void Dispose()
        {

        }
    }
}
