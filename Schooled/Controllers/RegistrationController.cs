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
            var entity = new Registration(studentNumber: model.StudentNumber, term: model.Term);
            var RegistrationRepository = new RegistrationRepository();
            await RegistrationRepository.Save(entity);
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
}