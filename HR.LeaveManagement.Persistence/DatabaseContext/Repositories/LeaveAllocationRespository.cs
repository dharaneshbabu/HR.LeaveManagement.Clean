using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly HrDatabaseContext _context;

    //private readonly 
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
        this._context = context;
    }

}
