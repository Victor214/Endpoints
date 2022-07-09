using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.DeleteEndpoint
{
    public interface IDeleteEndpoint
    {
        Task Execute(DeleteEndpointModel model);
    }
}
