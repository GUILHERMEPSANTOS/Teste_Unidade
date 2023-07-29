using FluentValidation.Results;

namespace Features.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}