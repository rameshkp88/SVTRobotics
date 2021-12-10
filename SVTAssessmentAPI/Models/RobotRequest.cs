using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Models
{
    public class RobotRequest
    {
        [JsonProperty]
        public int LoadId { get; set; }
        [JsonProperty]
        public int X { get; set; }
        [JsonProperty]
        public int Y { get; set; }

    }
}
