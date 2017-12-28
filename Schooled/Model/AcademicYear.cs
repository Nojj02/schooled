namespace Schooled.Model
{
    public class AcademicYear
    {
        public AcademicYear(Month startMonth, Year startYear, Month endMonth, Year endYear)
        {
            Contract.Requires(endYear >= startYear);

            StartMonth = startMonth;
            StartYear = startYear;
            EndMonth = endMonth;
            EndYear = endYear;
        }

        public Month StartMonth { get; }

        public Year StartYear { get; }

        public Month EndMonth { get; }

        public Year EndYear { get; }

        public override string ToString()
        {
            return $"{StartYear}-{EndYear}";
        }
    }
}