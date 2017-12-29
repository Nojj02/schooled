using System;
using System.Collections.Generic;

namespace Schooled.Model
{
    public class Registration
    {
        private readonly List<Course> _courses = new List<Course>();

        public Registration(string studentNumber, AcademicTerm academicTerm, IEnumerable<Course> courses)
        {
            StudentNumber = studentNumber;
            AcademicTerm = academicTerm;
            _courses.AddRange(courses);
        }

        public string StudentNumber { get; }

        public AcademicTerm AcademicTerm { get; }

        public IReadOnlyList<Course> Courses => _courses;

        public void Update(IEnumerable<Course> courses)
        {
            _courses.Clear();
            _courses.AddRange(courses);
        }
    }
}