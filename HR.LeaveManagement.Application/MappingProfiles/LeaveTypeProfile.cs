using AutoMapper;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.CreareLeaveType;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Commands.UpdateLeaveTypeCommand;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Queries.GetAllLeaveTypeDetails;
using HR.LeaveManagement.Application.Fetaures.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveTypeProfile: AutoMapper.Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>();

        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }
}
