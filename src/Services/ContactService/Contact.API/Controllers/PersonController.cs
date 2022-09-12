using Contact.Application.Commands.Request;
using Contact.Application.Commands.Response;
using Contact.Application.Queries.Request;
using Contact.Application.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetPersonQueryRequest request)
        {
            try
            {
                GetPersonQueryResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("get-list")]
        public async Task<IActionResult> GetList([FromQuery] ListPersonQueryRequest request)
        {
            try
            {
                List<ListPersonQueryResponse> response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody]CreatePersonCommandRequest request)
        {
            try
            {
                CreatePersonCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeletePersonCommandRequest request)
        {
            try
            {
                DeletePersonCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost("add-contact-info")]
        public async Task<IActionResult> AddContactInfo([FromBody] AddPersonContactInfoCommandRequest request)
        {
            try
            {
                AddPersonContactInfoCommandResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("get-person-report")]
        public async Task<IActionResult> GetPersonReport([FromQuery] GetPersonReportQueryRequest request)
        {
            try
            {
                GetPersonReportQueryResponse response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
