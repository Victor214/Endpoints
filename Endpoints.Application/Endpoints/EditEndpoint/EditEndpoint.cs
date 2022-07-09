using Endpoints.Application.Interfaces;
using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.EditEndpoint
{
    public class EditEndpoint : IEditEndpoint
    {
        private readonly IEndpointRepository _endpointRepository;

        public EditEndpoint(
            IEndpointRepository endpointRepository
            )
        {
            _endpointRepository = endpointRepository;
        }

        public async Task Execute(EditEndpointModel model)
        {
            Endpoint? existingEndpoint = await _endpointRepository.GetEndpointBySerialNumberAsync(model.EndpointSerialNumber);
            if (existingEndpoint == null)
                throw new ValidationException("No endpoint was found with the given serial number.");

            existingEndpoint.SetSwitchState(model.SwitchState);

            _endpointRepository.Update(existingEndpoint);
            await _endpointRepository.SaveAsync();
        }
    }
}
