using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Fetaures.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailQueryHandler : IRequestHandler<GetLeaveRequestDetailQuery, LeaveRequestDetailDto>
{
    private readonly IMapper _mapper;
    private readonly IAppLogger<LeaveRequestDetailDto> _logger;
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public GetLeaveRequestDetailQueryHandler(IMapper mapper,
        IAppLogger<LeaveRequestDetailDto> logger, 
        ILeaveRequestRepository leaveRequestRepository)
    {
        this._mapper = mapper;
        this._logger = logger;
        this._leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest == null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Id);
        }

        var data = _mapper.Map<LeaveRequestDetailDto>(leaveRequest);

        return data;
    }
}
