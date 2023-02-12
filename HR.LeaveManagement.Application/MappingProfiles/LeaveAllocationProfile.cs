﻿using AutoMapper;
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
		CreateMap<LeaveAllocation, LeaveAllocationDetailDto>();
	}
}
