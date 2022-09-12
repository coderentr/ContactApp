using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using reportBgService.Models;
using reportBgService.Models.Request;
using reportBgService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reportBgService.Services
{
    public class ContractService  
    {
        private readonly AppSettings _appSettings;
        public ContractService(IOptions<AppSettings> configuration)
        {
            _appSettings = configuration.Value;
        }
        public async Task<ReportResponse> GetReport(ReportRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var url = $"{_appSettings.BaseUrl}/Person/get-person-report?Location={request.Location}";
            using HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            var r=JsonConvert.SerializeObject(result);
            return new ReportResponse();
        }
    }
}
