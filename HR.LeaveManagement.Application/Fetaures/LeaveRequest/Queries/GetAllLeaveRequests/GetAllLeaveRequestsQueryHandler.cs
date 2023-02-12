using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveRequest.Queries.GetAllLeaveRequests;

public class GetAllLeaveRequestsQueryHandler : IRequestHandler<GetAllLeaveRequestQuery, List<LeaveRequestDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IAppLogger<LeaveRequestDto> _logger;

    public GetAllLeaveRequestsQueryHandler(IMapper mapper, 
        ILeaveRequestRepository leaveRequestRepository,
        IAppLogger<LeaveRequestDto> logger)
    {
        this._mapper = mapper;
        this._leaveRequestRepository = leaveRequestRepository;
        this._logger = logger;
    }
    public async Task<List<LeaveRequestDto>> Handle(GetAllLeaveRequestQuery request, CancellationToken cancellationToken)
    {
        // QUERY THE DB
        var leaveRequests = await _leaveRequestRepository.GetAllAsync();


        // CONVERT DATA OBJECTS TO DTO OBJECTS
        var data = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);

        // REturn LIST OF DTO OBJECT
        _logger.LogInformation("Leave requests were retrieved successfully.");

        return data;
    }
}
