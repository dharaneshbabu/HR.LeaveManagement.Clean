using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommand: IRequest<Unit>
{
    public int Id { get; set; }
}
