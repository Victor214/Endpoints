using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.CreateEndpoint
{
    public interface ICreateEndpoint
    {
        Task Execute(CreateEndpointModel model);
    }
}
