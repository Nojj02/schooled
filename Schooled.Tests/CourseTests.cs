using System;
using Xunit;

namespace Schooled.Tests
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