using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Fetaures.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {

            // QUERY THE DB
            var leaveTypes = await _leaveTypeRepository.GetAsync();


            // CONVERT DATA OBJECTS TO DTO OBJECTS
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            // REturn LIST OF DTO OBJECT
            _logger.LogInformation("Leave types were retrieved successfully.");

            return data;
            //throw new NotImplementedException();
        }
    }
}
