using Schooled.Model;
using Xunit;

namespace Schooled.Tests.Model
{
    public class CourseTests
    {
        [Fact]
        public void New()
        {
            var course =
                new Course(
                    code: "MATH 11",
                    name: "College Algebra");
            
            Assert.Equal("MATH 11", course.Code);
            Assert.Equal("College Algebra", course.Name);
        }
    }
}