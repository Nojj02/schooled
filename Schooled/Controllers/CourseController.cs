using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Schooled.DataAccess;
using Schooled.Models;

namespace Schooled.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        // GET api/course
        [HttpGet]
        public IEnumerable<CourseModel> Get()
        {
            var courseRepository = new CourseRepository();
            return courseRepository.GetAll().Select(x => new CourseModel(x));
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            var courseRepository = new CourseRepository();
            return courseRepository.Get(id);
        }

        // POST api/course
        [HttpPost]
        public async Task Post([FromBody]CoursePostModel model)
        {
            var entity = new Course(name: model.Name, code: model.Code);
            var courseRepository = new CourseRepository();
            await courseRepository.Save(entity);
        }
//
//        // PUT api/values/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }
//
//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
    }

    public class CourseModel
    {
        public CourseModel(Course course)
        {
            Name = course.Name;
            Code = course.Code;
        }

        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class CoursePostModel
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}