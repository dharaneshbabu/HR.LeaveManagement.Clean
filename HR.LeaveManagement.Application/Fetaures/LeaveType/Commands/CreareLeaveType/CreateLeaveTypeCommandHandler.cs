using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.CreareLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<CreateLeaveTypeCommandHandler> _logger;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<CreateLeaveTypeCommandHandler> logger)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
        this._logger = logger;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // VALIDATE REQUEST
        var validator = new CreateLeaveTypeCommandValidator(this._leaveTypeRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if(validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in create request for {0} and {1}", nameof(LeaveType), request);
            throw new BadRequestException("Invalid LeaveType", validationResult);
        }
        // CONVERT TO DOMAIN ENTITY

        var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);
        //ADD ENTITY TO DB

        await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

        // RETURN RECORD ID
        return leaveTypeToCreate.Id;
        throw new NotImplementedException();
    }
}
