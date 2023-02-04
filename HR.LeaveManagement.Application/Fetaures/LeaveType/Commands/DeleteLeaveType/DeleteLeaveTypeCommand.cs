using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
