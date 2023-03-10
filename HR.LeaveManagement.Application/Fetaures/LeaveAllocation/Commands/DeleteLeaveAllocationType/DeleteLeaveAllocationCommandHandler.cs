using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.DeleteLeaveAllocationType;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<DeleteLeaveAllocationCommand> _logger;

    public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
        IMapper mapper,
        IAppLogger<DeleteLeaveAllocationCommand> logger)
    {

        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
        this._logger = logger;
    }
    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);
        if (leaveAllocation == null)
        {
            throw new NotFoundException(nameof(LeaveAllocation), request.Id);
        }
        await _leaveAllocationRepository.DeleteAsync(leaveAllocation);

        return Unit.Value;
    }
}
