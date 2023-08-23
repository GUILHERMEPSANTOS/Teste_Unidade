using Bogus;
using Features.Clientes;
using Moq.AutoMock;
using static Bogus.DataSets.Name;

namespace Features.Tests.AutoMock
{
    public class ClienteTestsAutomockFixture
    {
        public AutoMocker Mocker;
        public ClienteService clienteService;
        public Cliente GerarClienteValido() => GerarListaDeClienteValidos(1, true).FirstOrDefault();

        public Cliente GerarClienteInvalido()
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

        public IEnumerable<Cliente> GerarClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(GerarListaDeClienteValidos(50, true));
            clientes.AddRange(GerarListaDeClienteValidos(50, false));

            return clientes;
        }

        public IEnumerable<Cliente> GerarListaDeClienteValidos(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Gender>();

            var clientesFaker = new Faker<Cliente>("pt_BR")
               .CustomInstantiator(faker => new Cliente(
                       nome: faker.Name.FirstName(genero),
                       sobrenome: faker.Name.LastName(genero),
                       email: "",
                       dataNascimento: faker.Date.Past(80, DateTime.UtcNow.AddYears(-18)),
                       dataCadastro: faker.Date.Past(3),
                       ativo: ativo
                 )).RuleFor(cliente => cliente.Email,
                           (faker, cliente) => faker.Internet.Email(cliente.Nome.ToLower(), cliente.Sobrenome.ToLower()));

            return clientesFaker.Generate(quantidade);
        }

        public ClienteService ObterClienteService()
        {
            Mocker = new AutoMocker();

            return Mocker.CreateInstance<ClienteService>();
        }

        public void Dispose()
        {

        }
    }

}
