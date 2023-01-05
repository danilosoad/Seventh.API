using MediatR;
using Seventh.Application.Responses.Recycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seventh.Application.Queries.Recycles
{
    public class GetRecycleStatusQuery : IRequest<GetRecycleStatusQueryResponse>
    {
    }
}
