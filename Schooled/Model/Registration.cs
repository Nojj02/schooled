using System;
using System.Collections;
using System.Collections.Generic;
using Schooled.Model.Events;

namespace Schooled.Model
{
    public class Registration : Entity
    {
        private readonly List<Course> _courses = new List<Course>();
        private readonly List<IRegistrationEvent> _events = new List<IRegistrationEvent>();
        private readonly List<IRegistrationEvent> _newEvents = new List<IRegistrationEvent>();

        public Registration(Guid id, string studentNumber, AcademicTerm academicTerm, IReadOnlyList<Course> courses)
            : base(id)
        {
            var thisEvent = 
                new RegistrationCreatedEvent(
                    id: id,
                    studentNumber: studentNumber,
                    academicTerm: academicTerm,
                    courses: courses);

            Apply(thisEvent, isNew: true);
        }

        public Registration(Guid id, IEnumerable<IRegistrationEvent> registrationEvents)
            : base(id)
        {
            foreach (var registrationEvent in registrationEvents)
            {
                switch (registrationEvent)
                {
                    case RegistrationCreatedEvent e:
                    {
                        Apply(e, isNew: false);
                        break;
                    }
                    case RegistrationCourseSelectionChangedEvent e:
                    {
                        Apply(e, isNew: false);
                        break;
                    }
                    default:
                        throw new UnknownOrUnsupportedDomainEventException(registrationEvent.GetType());
                }
            }
        }

        public string StudentNumber { get; private set; }

        public AcademicTerm AcademicTerm { get; private set; }

        public IReadOnlyList<Course> Courses => _courses;

        public IReadOnlyList<IRegistrationEvent> Events => _events;
        
        public IReadOnlyList<IRegistrationEvent> NewEvents => _newEvents;

        public void ChangeCourseSelection(IReadOnlyList<Course> courses)
        {
            var registrationCourseSelectionChangedEvent = new RegistrationCourseSelectionChangedEvent(Id, courses);
            Apply(registrationCourseSelectionChangedEvent, isNew: true);
        }

        private void Apply(RegistrationCreatedEvent e, bool isNew)
        {
            StudentNumber = e.StudentNumber;
            AcademicTerm = e.AcademicTerm;
            _courses.AddRange(e.Courses);
            
            AddEvent(e, isNew: isNew);
        }

        private void Apply(RegistrationCourseSelectionChangedEvent e, bool isNew)
        {
            _courses.Clear();
            _courses.AddRange(e.Courses);

            AddEvent(e, isNew: isNew);
        }

        private void AddEvent(IRegistrationEvent e, bool isNew)
        {
            _events.Add(e);
            if (isNew)
            {
                _newEvents.Add(e);
            }
        }
    }
}