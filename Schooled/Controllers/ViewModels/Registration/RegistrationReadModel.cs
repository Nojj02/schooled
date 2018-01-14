using System;
using System.Collections.Generic;
using System.Linq;
using Schooled.Model;

namespace Schooled.Controllers.RegistrationViewModels
{
    public class RegistrationReadModel
    {
        public RegistrationReadModel(Registration registration)
        {
            Id = registration.Id;
            StudentNumber = registration.StudentNumber;
            AcademicTerm = new AcademicTermReadModel(registration.AcademicTerm);
            Courses = registration.Courses
                .Select(x => new CourseReadModel(x))
                .ToList();
        }
        
        public Guid Id { get; set; }

        public string StudentNumber { get; set; }

        public AcademicTermReadModel AcademicTerm { get; set; }

        public IEnumerable<CourseReadModel> Courses { get; set; }
    }
}