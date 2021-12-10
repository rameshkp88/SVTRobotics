using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Models
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public object Message { get; set; }
        public T Data { get; set; }
    }
}
