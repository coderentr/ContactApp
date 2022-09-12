using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.Application.Commands.Request;
using Report.Application.Commands.Response;
using Report.Application.Queries.Request;
using Report.Application.Queries.Response;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        IMediator _mediatR;
        public ReportController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpGet("get-report")]
        public async Task<IActionResult> GetReport([FromQuery] CreateReportCommandRequest request)
        {
            try
            {
                CreateReportCommandResponse res = await _mediatR.Send(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost("update-report")]
        public async Task<IActionResult> UpdateReport([FromBody] UpdateReportCommandRequest request)
        {
            try
            {
                UpdateReportCommandResponse res = await _mediatR.Send(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("get-report-byId")]
        public async Task<IActionResult> GetReportById([FromQuery] GetReportQueryRequest request)
        {
            try
            {
                GetReportQueryResponse res = await _mediatR.Send(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("get-report-list")]
        public async Task<IActionResult> GetReportList([FromQuery] GetReportListQueryRequest request)
        {
            try
            {
                GetReportListQueryResponse res = await _mediatR.Send(request);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
