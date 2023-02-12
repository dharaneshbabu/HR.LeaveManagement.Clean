using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.CreateLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.DeleteLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.UpdateLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
        {
            var leaveAllocationDetails = await _mediator.Send(new GetLeaveAllocationsQuery());

            return Ok(leaveAllocationDetails);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<LeaveAllocationDetailDto>> Get(int id)
        {
            var leaveAllocationDetail = await _mediator.Send(new GetLeaveAllocationDetailsQuery() { Id = id });

            return Ok(leaveAllocationDetail);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post(CreateLeaveAllocationTypeCommand leaveAllocationCommand)
        {
            var response = await _mediator.Send(leaveAllocationCommand);

            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<LeaveAllocationsController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(UpdateLeaveAllocationCommand leaveAllocationCommand)
        {
            await _mediator.Send(leaveAllocationCommand);
            return NoContent();

        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
