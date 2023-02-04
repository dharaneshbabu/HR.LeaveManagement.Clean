﻿using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.UpdateLeaveTypeCommand;

public class UpdateLeaveTypeCommand:  IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;

    public int DefaultDays { get; set; }
}
