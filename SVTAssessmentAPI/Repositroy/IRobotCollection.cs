using Microsoft.Extensions.Configuration;
using SVTAssessmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Repositroy
{
   public interface IRobotCollection
    {
        Task<List<RobotInfo>> GetAllRobotInfo(IConfiguration _configuration);

    }
}
