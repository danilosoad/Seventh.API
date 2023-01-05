using MediatR;
using Seventh.Application.Responses.Recycles;

namespace Seventh.Application.Commands.Recycles
{
    public class RecycleVideoCommand : IRequest<RecycleVideoCommandResponse>
    {
        public int Days { get; set; }

        protected RecycleVideoCommand()
        { }

        public RecycleVideoCommand(int days)
        {
            Days = days;
        }
    }
}