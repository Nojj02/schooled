using System.Collections.Generic;
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

            var courses =
                new List<Course>
                {
                    new Course(
                        code: "Math11",
                        name: "Basic Math",
                        units: 3)
                };

            var registration =
                new Registration(
                    studentNumber: "016-00125",
                    academicTerm: academicTerm,
                    courses: courses);
            
            Assert.Equal("016-00125", registration.StudentNumber);
            Assert.Equal("2040-1", registration.AcademicTerm.ToString());
            Assert.Equal(1, registration.Courses.Count);
            Assert.Equal("Math11", registration.Courses[0].Code);
        }
    }
}