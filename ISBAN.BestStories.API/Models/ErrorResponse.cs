﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISBAN.BestStories.API.Models
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
