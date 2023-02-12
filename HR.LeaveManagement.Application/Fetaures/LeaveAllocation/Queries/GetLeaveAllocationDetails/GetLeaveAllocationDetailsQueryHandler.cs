using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Queries.GetAllLeaveTypeDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery ,LeaveAllocationDetailDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IAppLogger<LeaveAllocationDetailDto> _logger;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailsQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, 
        IAppLogger<LeaveAllocationDetailDto> logger,
        IMapper mapper
        )
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._logger = logger;
        this._mapper = mapper;
    }
    public async Task<LeaveAllocationDetailDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocationDetail = await _leaveAllocationRepository.GetByIdAsync(request.Id);

        if (leaveAllocationDetail == null)
        {
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);
        }

        var data = _mapper.Map<LeaveAllocationDetailDto>(leaveAllocationDetail);

        return data;
    }
}
