using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailQuery: IRequest<LeaveRequestDetailDto>
{
    public int Id { get; set; }
}
