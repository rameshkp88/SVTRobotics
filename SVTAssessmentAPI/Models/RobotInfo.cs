using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Models
{
    /// <summary>
    /// To Store the Robot Info
    /// </summary>
    public class RobotInfo
    {
        [JsonProperty]
        public int RobotId { get; set; }
        [JsonProperty]
        public int batteryLevel { get; set; }
        [JsonProperty]
        public int X { get; set; }
        [JsonProperty]
        public int Y { get; set; }

        public Double MyDistance { get; set; }
        public Double Distance(int xInput, int yInput)
        {
            int a = Math.Abs(this.X - xInput);
            int b = Math.Abs(this.Y - yInput);
            return Math.Sqrt((a * a) + (b * b));
        }

    }
}
