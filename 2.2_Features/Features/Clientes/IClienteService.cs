namespace Features.Clientes
{
    internal interface IClienteService : IDisposable
    {
        IEnumerable<Cliente> ObterTodosAtivos();
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Inativar(Cliente cliente);
        void Remover(Cliente cliente);
    }
}
