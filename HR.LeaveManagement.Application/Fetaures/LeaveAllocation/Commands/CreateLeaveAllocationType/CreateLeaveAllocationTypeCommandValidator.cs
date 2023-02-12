using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.CreateLeaveAllocationType;

public class CreateLeaveAllocationTypeCommandValidator: AbstractValidator<CreateLeaveAllocationTypeCommand>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public CreateLeaveAllocationTypeCommandValidator(ILeaveAllocationRepository	leaveAllocationRepository)
	{
        this._leaveAllocationRepository = leaveAllocationRepository;

        RuleFor(p => p.NumberOfDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100.")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1.");
    }
}
