using FluentValidation;

namespace Features.Clientes
{
    internal class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 e 150 caracteres");

            RuleFor(cliente => cliente.Nome)
               .NotEmpty()
               .WithMessage("Nome não pode ser vazio")
               .Length(2, 150)
               .WithMessage("O Nome deve ter entre 2 e 150 caracteres");

            RuleFor(cliente => cliente.DataNascimento)
                .Must(HaveMinimumAge)
                .WithMessage("Você precisa ter 18 anos ou mais");

            RuleFor(cliente => cliente.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(cliente => cliente.Id)
                .NotEqual(Guid.Empty);
        }

        public bool HaveMinimumAge(DateTime nascimento)
        {
            return nascimento >= DateTime.UtcNow.AddYears(-18);
        }
    }
}
