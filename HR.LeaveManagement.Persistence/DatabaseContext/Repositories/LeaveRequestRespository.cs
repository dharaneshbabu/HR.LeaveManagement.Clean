﻿using HR.LeaveManagement.Application.Contracts.Persistence;
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

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
        var leaveRequests = await _context.LeaveRequests.Include(q => q.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
    {
        var leaveRequests = await _context.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
            .Include(p => p.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }
}