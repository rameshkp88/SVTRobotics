using Microsoft.Extensions.Configuration;
using SVTAssessmentAPI.Models;
using SVTAssessmentAPI.Utitlites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Repositroy
{
    public class RobotCollection : IRobotCollection
    {

        public async Task<List<RobotInfo>> GetAllRobotInfo(IConfiguration _configuration)
        {
            APIClient client = new APIClient(_configuration);
            return await client.GetRobotInfo();
        }
    }
}
