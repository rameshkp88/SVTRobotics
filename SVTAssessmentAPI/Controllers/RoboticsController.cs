using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SVTAssessmentAPI.Models;
using SVTAssessmentAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Controllers
{
    [Route("api/Robots")]
    [ApiController]
    public class RoboticsController : ControllerBase
    {
        private IRobotService _roboService;
        public RoboticsController(IRobotService iRobo)
        {
            _roboService = iRobo;
        }
        [HttpGet]
        [Route("api/Robots/Get")]
        public async Task<ActionResult> GetAllRobotInfo()
        {
           var result= await _roboService.GetAllRobotInfo();
           return Ok(result);
        }

        [HttpPost]
        [Route("api/Robots/CheckNearest")]
        public async Task<ActionResult> CheckNearest([FromBody] RobotRequest request)
        {
            var result = await _roboService.GetNearest(request);
            return Ok(result);
        }

    }
}
