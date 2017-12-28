using Schooled.Model;

namespace Schooled.Controllers
{
    public class AcademicTermReadModel
    {
        public AcademicTermReadModel(AcademicTerm academicTerm)
        {
            Value = academicTerm.Value;
            StartYear = academicTerm.AcademicYear.StartYear.Value;
            EndYear = academicTerm.AcademicYear.EndYear.Value;
        }

        public int Value { get; set; }

        public int StartYear { get; set; }

        public int EndYear { get; set; }
    }
}