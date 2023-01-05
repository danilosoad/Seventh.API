using MediatR;
using Seventh.Application.Responses.Server;

namespace Seventh.Application.Queries.Server
{
    public class GetAllServersQuery : IRequest<GetAllServersQueryResponse>
    {
    }
}