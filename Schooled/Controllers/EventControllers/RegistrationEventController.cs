using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Schooled.DataAccess;
using Schooled.Model.Events;

namespace Schooled.Controllers.EventControllers
{
    [Route("events/[controller]")]
    public class RegistrationEventController : Controller
    {
        [HttpGet]
        public IEnumerable<EventStoreItemReadModel> Get()
        {
            var registrationEventRepository = new RegistrationEventRepository();
            
            return registrationEventRepository.GetAll()
                .Select(x =>
                    new EventStoreItemReadModel
                    {
                        Id = x.Id,
                        EventType = x.EventType,
                        Event = x.Event,
                        TimeStamp = x.TimeStamp
                    })
                .ToList();
        }
    }
}