using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.EditEndpoint
{
    public interface IEditEndpoint
    {
        Task Execute(EditEndpointModel model);
    }
}
