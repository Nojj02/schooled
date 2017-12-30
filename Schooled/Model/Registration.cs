using System;
using System.Collections.Generic;

namespace Schooled.Model
{
    public class Registration : Entity
    {
        private readonly List<Course> _courses = new List<Course>();

        public Registration(Guid id, string studentNumber, AcademicTerm academicTerm, IEnumerable<Course> courses)
            : base(id)
        {
            StudentNumber = studentNumber;
            AcademicTerm = academicTerm;
            _courses.AddRange(courses);
        }

        public string StudentNumber { get; }

        public AcademicTerm AcademicTerm { get; }

        public IReadOnlyList<Course> Courses => _courses;

        public void ChangeCourseSelection(IEnumerable<Course> courses)
        {
            _courses.Clear();
            _courses.AddRange(courses);
        }
    }
}