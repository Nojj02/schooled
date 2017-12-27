namespace Schooled.Model
{
    public class Course
    {
        public Course(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public string Code { get; }

        public string Name { get; }
    }
}