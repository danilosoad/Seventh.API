using MediatR;
using Seventh.Application.Queries.Recycles;
using Seventh.Application.Responses.Recycles;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Resources;

namespace Seventh.Application.Handlers.Recycles
{
    public class GetRecycleStatusQueryHandler : IRequestHandler<GetRecycleStatusQuery, GetRecycleStatusQueryResponse>
    {
        private readonly IServerRepository _serverRepository;

        public GetRecycleStatusQueryHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<GetRecycleStatusQueryResponse> Handle(GetRecycleStatusQuery request, CancellationToken cancellationToken)
        {
            var response = await _serverRepository.GetRecycleStatusAsync();

            if (response == null)
                return new GetRecycleStatusQueryResponse() { Message = ResponseMessages.JobNotRunning };

            return new GetRecycleStatusQueryResponse() { Message = response.Status };
        }
    }
}