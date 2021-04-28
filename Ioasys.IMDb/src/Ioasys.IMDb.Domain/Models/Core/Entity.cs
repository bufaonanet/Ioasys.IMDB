using System;
using System.Diagnostics.CodeAnalysis;

namespace Ioasys.IMDb.Domain
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Id { get; set; }

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
