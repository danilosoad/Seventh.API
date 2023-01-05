using Hangfire;
using MediatR;
using Seventh.Application.Commands.Recycles;
using Seventh.Application.Responses.Recycles;
using Seventh.Domain.Entities.Recycles;
using Seventh.Domain.Entities.Servers.Repository;

namespace Seventh.Application.Handlers.Recycles
{
    public class RecycleVideoCommandHandler : IRequestHandler<RecycleVideoCommand, RecycleVideoCommandResponse>
    {
        private readonly IServerRepository _serverRepository;
        private const string STATUS_RUNNING = "running";
        private const string STATUS_NOT_RUNNING = "not running";

        public RecycleVideoCommandHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<RecycleVideoCommandResponse> Handle(RecycleVideoCommand request, CancellationToken cancellationToken)
        {
            var jobId = BackgroundJob.Enqueue(() => RecycleVideos(request.Days));

            var newRecycleJob = new Recycle(STATUS_RUNNING, jobId);
            await _serverRepository.AddRecycleAsync(newRecycleJob);

            BackgroundJob.ContinueJobWith(jobId, () => UpdateRecycleStatusJob(newRecycleJob));

            return new RecycleVideoCommandResponse();
        }

        public void RecycleVideos(int days)
        {
            _serverRepository.RecycleVideos(days);
        }

        public void UpdateRecycleStatusJob(Recycle recycle)
        {
            recycle.UpdateStatus(STATUS_NOT_RUNNING);
            _serverRepository.UpdateStatusRecycle(recycle);
        }
    }
}