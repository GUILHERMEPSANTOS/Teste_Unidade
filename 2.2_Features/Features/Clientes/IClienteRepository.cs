using Features.Core;

namespace Features.Clientes
{
    internal interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterClientePorEmail(string email);
        IEnumerable<Cliente> ObterTodos();
    }
}
