using Schooled.Model;

namespace Schooled.Controllers
{
    public class CourseReadModel
    {
        public CourseReadModel(Course course)
        {
            Code = course.Code;
            Name = course.Name;
            Units = course.Units;
        }

        public string Code { get; }

        public string Name { get; }

        public double Units { get; }
    }
}