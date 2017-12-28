using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Schooled.Controllers
{
    public class RegistrationPostModel
    {
        public RegistrationPostModel()
        {
            Courses = new List<CoursePostModel>();
        }

        public string StudentNumber { get; set; }

        public AcademicTermPostModel AcademicTerm { get; set; }

        public IEnumerable<CoursePostModel> Courses { get; set; }
    }
}