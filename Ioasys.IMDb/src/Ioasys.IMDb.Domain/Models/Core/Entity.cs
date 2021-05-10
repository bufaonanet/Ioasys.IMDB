using FluentValidation.Results;
using System;

namespace Ioasys.IMDb.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}
