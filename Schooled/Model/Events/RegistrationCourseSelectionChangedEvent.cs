using System;
using System.Collections.Generic;
using System.Linq;

namespace Schooled.Model.Events
{
    public class RegistrationCourseSelectionChangedEvent : IRegistrationEvent
    {
        public RegistrationCourseSelectionChangedEvent(
            Guid id,
            int version,
            IEnumerable<Course> courses)
        {
            Id = id;
            Version = version;
            Courses = courses.ToList();
        }
        
        public Guid Id { get; }
        
        public int Version { get; }

        public IReadOnlyList<Course> Courses { get; }
    }
}