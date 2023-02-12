using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.UpdateLeaveAllocationType;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateLeaveAllocationCommand> _logger;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper, 
        IAppLogger<UpdateLeaveAllocationCommand> logger,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        this._mapper = mapper;
        this._logger = logger;
        this._leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeToUpdate = _mapper.Map<Domain.LeaveAllocation>(request);

        await _leaveAllocationRepository.UpdateAsync(leaveTypeToUpdate);

        return Unit.Value;

    }
}
