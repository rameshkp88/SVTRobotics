using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Models
{
    public class RoboResponse
    {
        [JsonProperty]
        public int RoboId { get; set; }
        [JsonProperty]
        public Double DistanceToGoal { get; set; }
        [JsonProperty]
        public int BatteryLevel { get; set; }
    }
}
