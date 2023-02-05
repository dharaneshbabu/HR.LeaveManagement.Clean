using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.DatabaseContext.Repositories;

public class LeaveTypeRespository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly HrDatabaseContext _context;

    //private readonly 
    public LeaveTypeRespository(HrDatabaseContext context) : base(context)
    {
        this._context = context;
    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
    }

    public async Task<bool> LeaveTypeMustExist(int id)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Id == id);
    }
}
