using System.Collections.Generic;

namespace Schooled.Controllers.RegistrationViewModels
{
    public class RegistrationPostModel
    {
        public RegistrationPostModel()
        {
            Courses = new List<CoursePostModel>();
        }

        public string StudentNumber { get; set; }

        public AcademicTermPostModel AcademicTerm { get; set; }

        public IEnumerable<CoursePostModel> Courses { get; set; }
    }
}