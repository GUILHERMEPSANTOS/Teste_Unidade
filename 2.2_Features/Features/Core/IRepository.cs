using Features.Clientes;

namespace Features.Core
{

    public interface IRepository<TClass> : IDisposable where TClass : Entity
    {
        void Adicionar(TClass cliente);
        void Atualizar(TClass cliente);
        void Inativar(TClass cliente);
        void Remover(Guid Id);
    }
}
