using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler: IRequestHandler<UpdateLeaveRequestCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IAppLogger<UpdateLeaveRequestCommand> _logger;

    public UpdateLeaveRequestCommandHandler(IMapper mapper,
        ILeaveRequestRepository leaveRequestRepository,
        IAppLogger<UpdateLeaveRequestCommand> logger)
	{
        this._mapper = mapper;
        this._leaveRequestRepository = leaveRequestRepository;
        this._logger = logger;
    }

    public async Task<int> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestUpdate = _mapper.Map<Domain.LeaveRequest>(request);

        await _leaveRequestRepository.UpdateAsync(leaveRequestUpdate);

        return leaveRequestUpdate.Id;
    }
}
