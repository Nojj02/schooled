using Schooled.Model;
using Xunit;

namespace Schooled.Tests.Model
{
    public class AcademicTermTests
    {
        [Fact]
        public void New()
        {
            var academicYear = 
                new AcademicYear(
                    startYear: 2040,
                    endYear: 2041);

            var academicTerm =
                new AcademicTerm(
                    value: 1,
                    academicYear: academicYear);

            Assert.Equal(1, academicTerm.Value);
            Assert.Equal("2040-2041", academicTerm.AcademicYear.ToString());
        }
    }
}