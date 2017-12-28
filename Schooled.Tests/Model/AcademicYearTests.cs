using Schooled.Model;
using Xunit;

namespace Schooled.Tests.Model
{
    public class AcademicYearTests
    {
        [Fact]
        public void New()
        {
            var academicYear =
                new AcademicYear(
                    startMonth: Month.June,
                    startYear: 2040,
                    endMonth: Month.March,
                    endYear: 2041);

            Assert.Equal(Month.June, academicYear.StartMonth);
            Assert.Equal(2040, academicYear.StartYear);
            Assert.Equal(Month.March, academicYear.EndMonth);
            Assert.Equal(2041, academicYear.EndYear);
        }
    }
}