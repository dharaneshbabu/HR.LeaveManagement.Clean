using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveRequestRespository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly HrDatabaseContext _context;

    //private readonly 
    public LeaveRequestRespository(HrDatabaseContext context) : base(context)
    {
        this._context = context;
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
    }
}