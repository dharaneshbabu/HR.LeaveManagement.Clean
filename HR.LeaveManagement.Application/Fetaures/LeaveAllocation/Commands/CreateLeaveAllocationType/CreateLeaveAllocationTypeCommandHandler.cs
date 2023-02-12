using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.CreareLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.CreateLeaveAllocationType;

public class CreateLeaveAllocationTypeCommandHandler : IRequestHandler<CreateLeaveAllocationTypeCommand, int>
{
    private readonly IAppLogger<CreateLeaveAllocationTypeCommand> _appLogger;
    private readonly IMapper _mapper;
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public CreateLeaveAllocationTypeCommandHandler(
        IAppLogger<CreateLeaveAllocationTypeCommand> appLogger,
        IMapper mapper,
        ILeaveAllocationRepository leaveAllocationRepository)
    {
        this._appLogger = appLogger;
        this._mapper = mapper;
        this._leaveAllocationRepository = leaveAllocationRepository;
    }
    public async Task<int> Handle(CreateLeaveAllocationTypeCommand request, CancellationToken cancellationToken)
    {
        // VALIDATE REQUEST
        var validator = new CreateLeaveAllocationTypeCommandValidator(this._leaveAllocationRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            _appLogger.LogWarning("Validation errors in create request for {0} and {1}", nameof(LeaveAllocation), request);
            throw new BadRequestException("Invalid LeaveType", validationResult);
        }
        // CONVERT TO DOMAIN ENTITY

        var leaveAllocationToCreate = _mapper.Map<Domain.LeaveAllocation>(request);
        //ADD ENTITY TO DB

        await _leaveAllocationRepository.CreateAsync(leaveAllocationToCreate);

        // RETURN RECORD ID
        return leaveAllocationToCreate.Id;
    }
}
