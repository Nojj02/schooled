namespace Schooled.Model
{
    public class AcademicTerm
    {
        public AcademicTerm(int value, AcademicYear academicYear)
        {
            Value = value;
            AcademicYear = academicYear;
        }

        public int Value { get; }

        public AcademicYear AcademicYear { get; }

        public override string ToString()
        {
            return $"{AcademicYear.StartYear}-{Value}";
        }
    }
}