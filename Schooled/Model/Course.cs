namespace Schooled.Model
{
    public class Course
    {
        public Course(string code, string name, double units)
        {
            Code = code;
            Name = name;
            Units = units;
        }

        public string Code { get; }

        public string Name { get; }

        public double Units { get; }
    }
}