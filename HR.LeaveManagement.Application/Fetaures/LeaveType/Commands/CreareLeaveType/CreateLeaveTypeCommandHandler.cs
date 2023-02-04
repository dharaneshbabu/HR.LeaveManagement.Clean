using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.CreareLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        // VALIDATE REQUEST
        var validator = new CreateLeaveTypeCommandValidator(this._leaveTypeRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if(validationResult.Errors.Any())
        {
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
