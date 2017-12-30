using System;

namespace Schooled.Model
{
    public class UnknownOrUnsupportedDomainEventException : Exception
    {
        public UnknownOrUnsupportedDomainEventException(object obj)
            : base($"{obj.GetType().FullName} is unknown or unsupported by this entity")
        {
        }
    }
}