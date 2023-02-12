using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveAllocation.Commands.CreateLeaveAllocationType
{
    public class CreateLeaveAllocationTypeCommand: IRequest<int>
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        //public  LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
    }
}
