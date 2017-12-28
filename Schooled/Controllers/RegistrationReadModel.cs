using System.Collections.Generic;
using System.Linq;
using Schooled.Model;

namespace Schooled.Controllers
{
    public class RegistrationReadModel
    {
        public RegistrationReadModel(Registration registration)
        {
            StudentNumber = registration.StudentNumber;
            AcademicTerm = new AcademicTermReadModel(registration.AcademicTerm);
            Courses = registration.Courses
                .Select(x => new CourseReadModel(x))
                .ToList();
        }

        public string StudentNumber { get; set; }

        public AcademicTermReadModel AcademicTerm { get; set; }

        public IEnumerable<CourseReadModel> Courses { get; set; }
    }
}