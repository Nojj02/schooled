using Schooled.Model;
using Xunit;

namespace Schooled.Tests.Model
{
    public class RegistrationTests
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

            var registration =
                new Registration(
                    studentNumber: "016-00125",
                    academicTerm: academicTerm);
            
            Assert.Equal("016-00125", registration.StudentNumber);
            Assert.Equal("2040-1", registration.AcademicTerm.ToString());
        }
    }
}