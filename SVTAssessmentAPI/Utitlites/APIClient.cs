using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SVTAssessmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SVTAssessmentAPI.Utitlites
{
    public class APIClient
    {

        /// <summary>
        /// Retry Count
        /// </summary>
        public static int RETRY_COUNT = 3;
        /// <summary>
        /// Task Delay
        /// </summary>
        public static int TASK_DELAY = 3000;
        IConfiguration configuration;
        public APIClient(IConfiguration iConfiguration)
        {
            configuration = iConfiguration;
        }

        public async Task<List<RobotInfo>> GetRobotInfo()
        {
            string uri =  configuration[RoboticConstants.ConfigRoboticInformationSource];
            return await Get<List<RobotInfo>>(uri);
        }
        /// <summary>
        /// Get the value from string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private async Task<T> Get<T>(string uri)
        {
            string responseBody = string.Empty;
            var retriedCount = 0;
            while (retriedCount < RETRY_COUNT)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        using (HttpResponseMessage response = await client.GetAsync(uri))
                        {
                            response.EnsureSuccessStatusCode();
                            responseBody = await response.Content.ReadAsStringAsync();
                            retriedCount = RETRY_COUNT;
                        }
                    }

                }
                catch (Exception ex)
                {
                    retriedCount++;
                    if (retriedCount == RETRY_COUNT)
                    {
                        throw;
                    }
                    await Task.Delay(TASK_DELAY);

                }
            }

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
