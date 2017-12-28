using Schooled.Model;

namespace Schooled.Controllers
{
    public class RegistrationReadModel
    {
        public RegistrationReadModel(Registration registration)
        {
            StudentNumber = registration.StudentNumber;
            Term = registration.Term;
        }

        public string StudentNumber { get; set; }

        public string Term { get; set; }
    }
}