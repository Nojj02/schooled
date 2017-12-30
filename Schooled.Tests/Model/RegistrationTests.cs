using System;
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

            var id = Guid.NewGuid();
            var registration =
                new Registration(id, 
                    studentNumber: "016-00125",
                    academicTerm: academicTerm,
                    courses: courses);
            
            Assert.Equal("016-00125", registration.StudentNumber);
            Assert.Equal("2040-1", registration.AcademicTerm.ToString());
            Assert.Equal(1, registration.Courses.Count);
            Assert.Equal("Math11", registration.Courses[0].Code);
            
            Assert.Equal(1, registration.Events.Count);
            var createdEvent = (RegistrationCreatedEvent)registration.Events[0];
            
            Assert.Equal(id, createdEvent.Id);
            Assert.Equal("016-00125", createdEvent.StudentNumber);
            Assert.Equal("2040-1", createdEvent.AcademicTerm.ToString());
            Assert.Equal(1, createdEvent.Courses.Count);
            Assert.Equal("Math11", createdEvent.Courses[0].Code);
            
        }
        
        [Fact]
        public void ChangeCourseSelection()
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
                new Registration(Guid.NewGuid(), 
                    studentNumber: "016-00125",
                    academicTerm: academicTerm,
                    courses: courses);

            var newCourses =
                new List<Course>
                {
                    new Course(
                        code: "MMS100",
                        name: "Introduction to Multimedia",
                        units: 3),
                    new Course(
                        code: "MMS112",
                        name: "Multimedia and Law",
                        units: 3)
                };

            registration.ChangeCourseSelection(
                courses: newCourses);
            
            Assert.Equal("016-00125", registration.StudentNumber);
            Assert.Equal("2040-1", registration.AcademicTerm.ToString());
            Assert.Equal(2, registration.Courses.Count);
            Assert.Equal("MMS100", registration.Courses[0].Code);
            Assert.Equal("MMS112", registration.Courses[1].Code);
        }
    }
}