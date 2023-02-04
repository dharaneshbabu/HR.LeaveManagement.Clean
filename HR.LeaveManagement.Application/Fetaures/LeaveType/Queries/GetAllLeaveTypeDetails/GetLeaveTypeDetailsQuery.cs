using HR.LeaveManagement.Application.Fetaures.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Queries.GetAllLeaveTypeDetails;

//public class GetLeaveTypeDetailsQuery : IRequest<LeaveTypeDetailsDto>
//{
//    public int Id { get; set; }
//}


public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;