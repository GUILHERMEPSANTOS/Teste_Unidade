using Features.Core;

namespace Features.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterClientePorEmail(string email);
        IEnumerable<Cliente> ObterTodos();
    }
}
