using Schooled.Model;
using Xunit;

namespace Schooled.Tests.Model
{
    public class RegistrationTests
    {
        [Fact]
        public void New()
        {
            var registration =
                new Registration(
                    studentNumber: "016-00125",
                    term: "1st semester 2040");
            
            Assert.Equal("016-00125", registration.StudentNumber);
            Assert.Equal("1st semester 2040", registration.Term);
        }
    }
}