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
                    startYear: 2040,
                    endYear: 2041);

            Assert.Equal(2040, academicYear.StartYear);
            Assert.Equal(2041, academicYear.EndYear);
        }
    }
}