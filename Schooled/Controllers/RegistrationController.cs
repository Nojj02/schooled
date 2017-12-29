using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schooled.DataAccess;
using Schooled.Model;

namespace Schooled.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        // GET api/Registration
        [HttpGet]
        public IEnumerable<RegistrationReadModel> Get()
        {
            var registrationRepository = new RegistrationRepository();
            return registrationRepository.GetAll().Select(x => new RegistrationReadModel(x));
        }

        // GET api/Registration/{id}
        [HttpGet("{id}")]
        public RegistrationReadModel Get(string id)
        {
            var registrationRepository = new RegistrationRepository();
            var entity = registrationRepository.Get(id);
            return new RegistrationReadModel(entity);
        }

        // POST api/Registration
        [HttpPost]
        public async Task Post([FromBody]RegistrationPostModel model)
        {
            var academicTerm =
                new AcademicTerm(
                    value: model.AcademicTerm.Value,
                    academicYear: 
                        new AcademicYear(
                            startYear: new Year(model.AcademicTerm.StartYear),
                            endYear: new Year(model.AcademicTerm.EndYear)
                    ));

            var entity = 
                new Registration(
                    studentNumber: model.StudentNumber, 
                    academicTerm: academicTerm,
                    courses: 
                        model.Courses
                            .Select(x => new Course(x.Code, x.Name, x.Units)));
            var registrationRepository = new RegistrationRepository();
            await registrationRepository.Save(entity);
        }
    }
}