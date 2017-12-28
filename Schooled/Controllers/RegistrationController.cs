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
            var RegistrationRepository = new RegistrationRepository();
            return RegistrationRepository.GetAll().Select(x => new RegistrationReadModel(x));
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            var RegistrationRepository = new RegistrationRepository();
            return RegistrationRepository.Get(id);
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
            var entity = new Registration(studentNumber: model.StudentNumber, academicTerm: academicTerm);
            var RegistrationRepository = new RegistrationRepository();
            await RegistrationRepository.Save(entity);
        }
    }
}