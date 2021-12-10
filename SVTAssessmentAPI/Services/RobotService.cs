using Microsoft.Extensions.Configuration;
using SVTAssessmentAPI.Models;
using SVTAssessmentAPI.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Services
{
    public class RobotService : IRobotService
    {
        private IRobotCollection _roboRepo;
        private IConfiguration _configuration;
        public RobotService(IRobotCollection repo, IConfiguration config)
        {
            _roboRepo = repo;
            _configuration = config;
        }
        public async Task<List<RobotInfo>> GetAllRobotInfo()
        {
            return await _roboRepo.GetAllRobotInfo(_configuration);
        }

        public async Task<RoboResponse> GetNearest(RobotRequest req)
        {
            RoboResponse objRes = new RoboResponse();
          
            var nearest10Devices = await GetRobotsWithIn10Unit(req);

            var roboWithHighBattery = nearest10Devices.OrderByDescending(x => x.batteryLevel).FirstOrDefault();
            objRes.BatteryLevel = roboWithHighBattery.batteryLevel;
            objRes.RoboId = roboWithHighBattery.RobotId;
            objRes.DistanceToGoal = roboWithHighBattery.MyDistance;
            return objRes;
        }

        #region Private
        private async Task<List<RobotInfo>> GetRobotsWithIn10Unit( RobotRequest req)
        {
            var allrobots = await _roboRepo.GetAllRobotInfo(_configuration);
            List<RobotInfo> nearest10Devices = new List<RobotInfo>();
            double minDist = double.MaxValue;
            double testDist;
           
            int idx = 0;
            for (int i = 0; i < allrobots.Count; i++)
            {
                testDist = allrobots[i].Distance(req.X, req.Y);

                if (testDist < minDist)
                {
                    idx = i;
                    minDist = testDist;
                    if (testDist < 10)
                    {
                        allrobots[i].MyDistance = testDist;
                        nearest10Devices.Add(allrobots[i]);
                    }
                }
            }

            return nearest10Devices;
        }

        #endregion
    }
}
