namespace Schooled.Model
{
    public class AcademicYear
    {
        public AcademicYear(Year startYear, Year endYear)
        {
            Contract.Requires(endYear >= startYear);

            StartYear = startYear;
            EndYear = endYear;
        }

        public Year StartYear { get; }

        public Year EndYear { get; }

        public override string ToString()
        {
            return $"{StartYear}-{EndYear}";
        }
    }
}