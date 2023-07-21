using System.ComponentModel.DataAnnotations;

namespace Features.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}