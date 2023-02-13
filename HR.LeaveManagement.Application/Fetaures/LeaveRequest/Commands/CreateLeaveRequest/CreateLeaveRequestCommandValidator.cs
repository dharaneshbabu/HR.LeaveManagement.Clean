using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandValidator: AbstractValidator<CreateLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public CreateLeaveRequestCommandValidator(ILeaveRequestRepository leaveRequestRepository)
	{
        this._leaveRequestRepository = leaveRequestRepository;



    }
}
