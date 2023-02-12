using AutoMapper;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.CreateLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.UpdateLeaveAllocationType;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
	public LeaveAllocationProfile()
	{
		CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
		CreateMap<LeaveAllocation, LeaveAllocationDetailDto>();
		CreateMap<CreateLeaveAllocationTypeCommand, LeaveAllocation>();
		CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
	}
}
