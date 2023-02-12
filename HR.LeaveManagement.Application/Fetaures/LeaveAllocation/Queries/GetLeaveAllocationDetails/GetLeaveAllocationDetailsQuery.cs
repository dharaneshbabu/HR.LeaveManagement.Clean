using MediatR;
namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQuery: IRequest<LeaveAllocationDetailDto>
{
    public int Id { get; set; }
}
