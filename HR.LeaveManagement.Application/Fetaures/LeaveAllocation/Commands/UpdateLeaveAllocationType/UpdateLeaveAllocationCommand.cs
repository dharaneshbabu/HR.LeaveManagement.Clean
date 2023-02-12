using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.UpdateLeaveAllocationType;

public class UpdateLeaveAllocationCommand: IRequest<Unit>
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}
