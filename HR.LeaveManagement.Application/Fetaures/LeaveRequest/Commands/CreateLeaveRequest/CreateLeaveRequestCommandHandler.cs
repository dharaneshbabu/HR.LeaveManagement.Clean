using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateLeaveRequestCommand> _logger;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public CreateLeaveRequestCommandHandler(IMapper mapper,
        IAppLogger<CreateLeaveRequestCommand> logger,
        ILeaveRequestRepository leaveRequestRepository)
    {
        this._mapper = mapper;
        this._logger = logger;
        this._leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        // VALIDATE REQUEST
        var validator = new CreateLeaveRequestCommandValidator(_leaveRequestRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in create request for {0} and {1}", nameof(LeaveRequest), request);
            throw new BadRequestException("Invalid Leave request", validationResult);
        }
        // CONVERT TO DOMAIN ENTITY

        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
        //ADD ENTITY TO DB

        await _leaveRequestRepository.CreateAsync(leaveRequest);

        // RETURN RECORD ID
        return leaveRequest.Id;
    }
}
