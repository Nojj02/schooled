using System;
using System.Collections.Generic;
using Schooled.Model.Events;

namespace Schooled.Model
{
    public class Registration : Entity
    {
        private readonly List<Course> _courses = new List<Course>();
        private readonly List<IRegistrationEvent> _events = new List<IRegistrationEvent>();

        public Registration(Guid id, string studentNumber, AcademicTerm academicTerm, IReadOnlyList<Course> courses)
            : base(id)
        {
            var thisEvent = 
                new RegistrationCreatedEvent(
                    id: id,
                    studentNumber: studentNumber,
                    academicTerm: academicTerm,
                    courses: courses);

            Apply(thisEvent);
        }

        public Registration(Guid id, IEnumerable<IRegistrationEvent> registrationEvents)
            : base(id)
        {
            foreach (var registrationEvent in registrationEvents)
            {
                switch (registrationEvent)
                {
                    case RegistrationCreatedEvent e:
                        Apply(e);
                        break;
                    default:
                        throw new UnknownOrUnsupportedDomainEventException(registrationEvent.GetType());
                }
            }
        }

        public string StudentNumber { get; private set; }

        public AcademicTerm AcademicTerm { get; private set; }

        public IReadOnlyList<Course> Courses => _courses;

        public IReadOnlyList<IRegistrationEvent> Events => _events;

        public void ChangeCourseSelection(IReadOnlyList<Course> courses)
        {
            _courses.Clear();
            _courses.AddRange(courses);

            _events.Add(new RegistrationCourseSelectionChangedEvent(Id, courses));
        }

        private void Apply(RegistrationCreatedEvent e)
        {
            StudentNumber = e.StudentNumber;
            AcademicTerm = e.AcademicTerm;
            _courses.AddRange(e.Courses);
            
            _events.Add(e);
        }
    }
}