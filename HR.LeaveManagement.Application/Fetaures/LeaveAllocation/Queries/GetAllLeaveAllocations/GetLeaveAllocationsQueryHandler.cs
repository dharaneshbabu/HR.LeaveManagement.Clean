using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
{
    private readonly IAppLogger<GetLeaveAllocationsQuery> _appLogger;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationsQueryHandler(IAppLogger<GetLeaveAllocationsQuery> appLogger,
        ILeaveAllocationRepository leaveAllocationRepository, 
        IMapper mapper)
    {
        this._appLogger = appLogger;
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
    {
        // QUERY THE DB
        var leaveTypes = await _leaveAllocationRepository.GetAllAsync();


        // CONVERT DATA OBJECTS TO DTO OBJECTS
        var data = _mapper.Map<List<LeaveAllocationDto>>(leaveTypes);

        // REturn LIST OF DTO OBJECT
        _appLogger.LogInformation("Leave allocations were retrieved successfully.");

        return data;
        //throw new NotImplementedException();
    }
}
