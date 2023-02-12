using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.CreareLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
	{
		this._leaveTypeRepository = leaveTypeRepository;

		RuleFor(p => p.Name)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.NotNull()
			.MaximumLength(70).WithMessage("{PropertyName} Must not exceed 70 characters.");

		RuleFor(p => p.DefaultDays)
			.LessThan(100).WithMessage("{PropertyName} cannot exceed 100.")
			.GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1.");

		RuleFor(p => p)
			.MustAsync(LeaveTypeNameUnique)
			.WithMessage("Leave type already exists.");

    }

    private async Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
		return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        throw new NotImplementedException();
    }
}
