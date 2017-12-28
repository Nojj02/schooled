using Schooled.Model;

namespace Schooled.Controllers
{
    public class RegistrationReadModel
    {
        public RegistrationReadModel(Registration registration)
        {
            StudentNumber = registration.StudentNumber;
            AcademicTerm = new AcademicTermReadModel(registration.AcademicTerm);
        }

        public string StudentNumber { get; set; }

        public AcademicTermReadModel AcademicTerm { get; set; }
    }
}