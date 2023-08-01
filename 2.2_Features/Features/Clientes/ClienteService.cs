

using MediatR;

namespace Features.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMediator _mediator;

        public ClienteService(IClienteRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public void Adicionar(Cliente cliente)
        {
            if(cliente.EhValido()) {

                _repository.Adicionar(cliente);
                _mediator.Publish(new ClienteEmailNotification("admin@me.com.br", cliente.Email, "Conta Criada", "Parabens"));
            }
        }

        public void Atualizar(Cliente cliente)
        {
            if (cliente.EhValido())
            {
                _repository.Atualizar(cliente);
                _mediator.Publish(new ClienteEmailNotification("admin@me.com.br", cliente.Email, "Conta Atualizada", "Parabens"));
            }
        }

        public void Inativar(Cliente cliente)
        {
            if(cliente.EhValido()) {
                cliente.Inativar();
                _repository.Atualizar(cliente);
                _mediator.Publish(new ClienteEmailNotification("admin@me.com.br", cliente.Email, "Conta Atualizada", "Parabens"));
            }
        }

        public IEnumerable<Cliente> ObterTodosAtivos()
        {
            return _repository.ObterTodos().Where(cliente => cliente.Ativo);
        }

        public void Remover(Cliente cliente)
        {
            if (cliente.EhValido())
            {       
                _repository.Remover(cliente.Id);
                _mediator.Publish(new ClienteEmailNotification("admin@me.com.br", cliente.Email, "Conta Atualizada", "Parabens"));
            }
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
