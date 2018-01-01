using System;

namespace Schooled.Model.Events
{
    public interface IRegistrationEvent
    {
        Guid Id { get; }
        
        int Version { get; }
    }
}