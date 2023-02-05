using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.CreareLeaveType;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.UpdateLeaveTypeCommand;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(LeaveTypeMustExist);

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} Must not exceed 70 characters.");

        RuleFor(p => p.DefaultDays)
            .GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100.")
            .LessThan(1).WithMessage("{PropertyName} cannot be less than 1.");

        RuleFor(p => p)
            .MustAsync(LeaveTypeNameUnique)
            .WithMessage("Leave type already exists.");

    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
    {
        return await _leaveTypeRepository.LeaveTypeMustExist(id);
    }

    private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}
