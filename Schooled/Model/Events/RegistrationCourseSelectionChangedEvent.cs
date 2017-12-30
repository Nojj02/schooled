using System;
using System.Collections.Generic;
using System.Linq;

namespace Schooled.Model.Events
{
    public class RegistrationCourseSelectionChangedEvent : IRegistrationEvent
    {
        public RegistrationCourseSelectionChangedEvent(Guid id, IEnumerable<Course> courses)
        {
            Id = id;
            Courses = courses.ToList();
        }
        
        public Guid Id { get; }

        public IReadOnlyList<Course> Courses { get; }
    }
}