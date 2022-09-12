using MassTransit;
using Newtonsoft.Json;
using Report.Shared.RabbitMq;
using reportBgService.Models.Request;
using reportBgService.Models.Response;
using reportBgService.Models;
using reportBgService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text.Json.Nodes;

namespace reportBgService
{
    public class ReportCunsomer : IConsumer<ReportMessage>
    {
        public async Task Consume(ConsumeContext<ReportMessage> context)
        {
            var message = context.Message;
           
            var response=await GetReport(new ReportRequest { Location = message.Location });
            if (response != null)
            {
             var res= await PrintExcelService.Print(response, message.ReportId);
                if (res.IsSuccess)
                {
                   await SentReportStatus(new UpdateReportRequest { FilePath =res.FilePath, ReportId=message.ReportId});
                }
            }
            await context.ConsumeCompleted;
        }
        public async Task<ReportResponse> GetReport(ReportRequest request)
        {
            try
            {
                var url = $"http://localhost:5124/api/Person/get-person-report?Location={request.Location}";
                using HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                string result = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<ReportResponse>(result);
                return res;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
        public async Task SentReportStatus(UpdateReportRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                var url = $"http://localhost:5104/api/Report/update-report";
                using HttpClient client = new HttpClient();
                var response = await client.PostAsync(url, content);
                string result = response.Content.ReadAsStringAsync().Result;
                var res = JsonConvert.DeserializeObject<BaseCommandResponse>(result);
            }
            catch (Exception)
            {
               
            }
        }
    }
}
