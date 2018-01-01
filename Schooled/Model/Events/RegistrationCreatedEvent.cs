using System;
using System.Collections.Generic;

namespace Schooled.Model.Events
{
    public class RegistrationCreatedEvent : IRegistrationEvent
    {
        public RegistrationCreatedEvent(
            Guid id, 
            int version, 
            string studentNumber, 
            AcademicTerm academicTerm, 
            IReadOnlyList<Course> courses)
        {
            Id = id;
            Version = version;
            StudentNumber = studentNumber;
            AcademicTerm = academicTerm;
            Courses = courses;
        }
        
        public Guid Id { get; }
        
        public int Version { get; }

        public string StudentNumber { get; }

        public AcademicTerm AcademicTerm { get; }

        public IReadOnlyList<Course> Courses { get; }
    }
}