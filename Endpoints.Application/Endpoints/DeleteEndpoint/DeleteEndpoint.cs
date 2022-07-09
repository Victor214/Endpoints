using Endpoints.Application.Interfaces;
using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.DeleteEndpoint
{
    public class DeleteEndpoint : IDeleteEndpoint
    {
        private readonly IEndpointRepository _endpointRepository;

        public DeleteEndpoint(
            IEndpointRepository endpointRepository
            )
        {
            _endpointRepository = endpointRepository;
        }

        public async Task Execute(DeleteEndpointModel model)
        {
            Endpoint? existingEndpoint = await _endpointRepository.GetEndpointBySerialNumberAsync(model.EndpointSerialNumber);
            if (existingEndpoint == null)
                throw new ValidationException("No endpoint was found with the given serial number.");

            _endpointRepository.Delete(existingEndpoint);
            await _endpointRepository.SaveAsync();
        }
    }
}
