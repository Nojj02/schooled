using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schooled.Controllers.RegistrationViewModels;
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
        public RegistrationReadModel Get(Guid id)
        {
            var registrationRepository = new RegistrationRepository();
            var entity = registrationRepository.Get(id);
            return entity != null ? new RegistrationReadModel(entity) : null;
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
                    id: Guid.NewGuid(), 
                    studentNumber: model.StudentNumber, 
                    academicTerm: academicTerm,
                    courses: model.Courses
                        .Select(x => new Course(x.Code, x.Name, x.Units))
                        .ToList());
            
            var registrationRepository = new RegistrationRepository();
            await registrationRepository.Save(entity, DateTimeOffset.UtcNow);
        }

        // POST api/Registration
        [HttpPut]
        public async Task Put([FromBody]RegistrationUpdateModel model)
        {
            var entity = new RegistrationRepository().Get(model.Id);
            entity.ChangeCourseSelection(
                courses: model.Courses
                    .Select(x => new Course(x.Code, x.Name, x.Units))
                    .ToList());
            
            var registrationRepository = new RegistrationRepository();
            await registrationRepository.Update(entity, DateTimeOffset.UtcNow);
        }
    }
}