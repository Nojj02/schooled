using System;
using System.Collections.Generic;
using System.Linq;

namespace Schooled.Model
{
    public class Registration : Entity
    {
        private readonly List<Course> _courses = new List<Course>();
        private readonly List<IRegistrationEvent> _events = new List<IRegistrationEvent>();

        public Registration(Guid id, string studentNumber, AcademicTerm academicTerm, IEnumerable<Course> courses)
            : base(id)
        {
            StudentNumber = studentNumber;
            AcademicTerm = academicTerm;
            _courses.AddRange(courses);
            
            _events.Add(new RegistrationCreatedEvent(this));
        }

        public string StudentNumber { get; }

        public AcademicTerm AcademicTerm { get; }

        public IReadOnlyList<Course> Courses => _courses;

        public IReadOnlyList<IRegistrationEvent> Events => _events;

        public void ChangeCourseSelection(IReadOnlyList<Course> courses)
        {
            _courses.Clear();
            _courses.AddRange(courses);
            
            _events.Add(new RegistrationCourseSelectionChangedEvent(Id, courses));
        }
    }

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

    public interface IRegistrationEvent
    {
        Guid Id { get; }
    }
}