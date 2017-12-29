using System;

namespace Schooled.Model
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}