﻿using System;
using System.Collections.Generic;

namespace Schooled.Controllers
{
    public class RegistrationUpdateModel
    {
        public RegistrationUpdateModel()
        {
            Courses = new List<CourseUpdateModel>();
        }
        
        public Guid Id { get; set; }

        public IEnumerable<CourseUpdateModel> Courses { get; set; }
    }
}