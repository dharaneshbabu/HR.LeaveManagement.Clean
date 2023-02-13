using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.CreateLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.DeleteLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.UpdateLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Fetaures.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Fetaures.LeaveRequest.Commands.DeleteLeaveRequest;
using HR.LeaveManagement.Application.Fetaures.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Fetaures.LeaveRequest.Queries.GetAllLeaveRequests;
using HR.LeaveManagement.Application.Fetaures.LeaveRequest.Queries.GetLeaveRequestDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<LeaveRequestController>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var leaveRequestDetails = await _mediator.Send(new GetAllLeaveRequestQuery());

            return Ok(leaveRequestDetails);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequestDetail = await _mediator.Send(new GetLeaveRequestDetailQuery() { Id = id });

            return Ok(leaveRequestDetail);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequestCommand)
        {
            var response = await _mediator.Send(leaveRequestCommand);

            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveRequestController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequestCommand)
        {
            await _mediator.Send(leaveRequestCommand);
            return NoContent();

        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
