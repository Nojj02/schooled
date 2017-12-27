namespace Schooled.Model
{
    public class Registration
    {
        public Registration(string studentNumber, string term)
        {
            StudentNumber = studentNumber;
            Term = term;
        }

        public string StudentNumber { get; }

        public string Term { get; }
    }
}