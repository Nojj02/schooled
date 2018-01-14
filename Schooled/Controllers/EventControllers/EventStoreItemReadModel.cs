using System;

namespace Schooled.Controllers.EventControllers
{
    public class EventStoreItemReadModel
    {
        public Guid Id { get; set; }
        
        public string EventType { get; set; }
        
        public dynamic Event { get; set; }
        
        public DateTimeOffset TimeStamp { get; set; }
    }
}