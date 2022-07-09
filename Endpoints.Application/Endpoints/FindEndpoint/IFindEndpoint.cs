using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.FindEndpoint
{
    public interface IFindEndpoint
    {
        Task<FindEndpointDto> Execute(FindEndpointModel model);
    }
}
