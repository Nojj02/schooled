﻿using System;

namespace Schooled.DataAccess
{
    public class EventStoreItem
    {
        public Guid Id { get; set; }
        
        public string EventType { get; set; }
        
        public object Event { get; set; }
        
        public DateTimeOffset TimeStamp { get; set; }
    }
}