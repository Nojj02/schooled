using System;
using System.Collections.Generic;

namespace Schooled.Model.Events
{
    public static class RegistrationEvents
    {
        public static readonly IReadOnlyDictionary<Type, string> EventTypeLookup =
            new Dictionary<Type, string>
            {
                { typeof(RegistrationCreatedEvent), "Schooled.Model.Events.RegistrationCreatedEvent" },
                { typeof(RegistrationCourseSelectionChangedEvent), "Schooled.Model.Events.RegistrationCourseSelectionChangedEvent" }
            };
    }
}