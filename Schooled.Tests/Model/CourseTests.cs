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
                    code: "math11",
                    name: "Basic Algebra",
                    units: 3);

            Assert.Equal("math11", course.Code);
            Assert.Equal("Basic Algebra", course.Name);
            Assert.Equal(3, course.Units);
        }
    }
}