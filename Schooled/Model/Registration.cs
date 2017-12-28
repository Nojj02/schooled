using System;

namespace Schooled.Model
{
    public class Registration
    {
        public Registration(string studentNumber, AcademicTerm academicTerm)
        {
            StudentNumber = studentNumber;
            AcademicTerm = academicTerm;
        }

        public string StudentNumber { get; }

        public AcademicTerm AcademicTerm { get; }
    }
}