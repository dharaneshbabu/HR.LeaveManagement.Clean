using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class GetLeaveAllocationsQuery: IRequest<List<LeaveAllocationDto>>
{

}
