using System;
using System.Collections.Generic;

namespace Schooled.Model
{
    public class RegistrationCreatedEvent : IRegistrationEvent
    {
        public RegistrationCreatedEvent(Registration registration)
        {
            Id = registration.Id;
            StudentNumber = registration.StudentNumber;
            AcademicTerm = registration.AcademicTerm;
            Courses = registration.Courses;
        }
        
        public Guid Id { get; }

        public string StudentNumber { get; }

        public AcademicTerm AcademicTerm { get; }

        public IReadOnlyList<Course> Courses { get; }
    }
}