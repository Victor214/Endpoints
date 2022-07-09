using Endpoints.Application.Endpoints.Common;

namespace Endpoints.Application.Endpoints.FindEndpoint
{
    public interface IFindEndpoint
    {
        Task<EndpointResultDto> Execute(FindEndpointModel model);
    }
}
