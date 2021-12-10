using Microsoft.Extensions.Configuration;
using SVTAssessmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Services
{
    public interface IRobotService
    {
        Task<List<RobotInfo>> GetAllRobotInfo();

        Task<RoboResponse> GetNearest(RobotRequest req);
    }
}
