using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.DeleteLeaveAllocationType;

public class DeleteLeaveAllocationCommand: IRequest<Unit>
{
    public int Id { get; set; }
}
