using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Schooled.Controllers
{
    public class RegistrationPostModel
    {
        public string StudentNumber { get; set; }

        public string Term { get; set; }
    }
}