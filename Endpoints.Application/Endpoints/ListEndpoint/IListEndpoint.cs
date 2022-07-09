using Endpoints.Application.Endpoints.Common;

namespace Endpoints.Application.Endpoints.ListEndpoint
{
    public interface IListEndpoint
    {
        Task<List<EndpointResultDto>> Execute();
    }
}
