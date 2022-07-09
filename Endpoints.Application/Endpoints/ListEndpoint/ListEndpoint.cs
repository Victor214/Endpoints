using Endpoints.Application.Endpoints.Common;
using Endpoints.Application.Interfaces;
using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Endpoints.ListEndpoint
{
    public class ListEndpoint : IListEndpoint
    {
        private readonly IEndpointRepository _endpointRepository;

        public ListEndpoint(
            IEndpointRepository endpointRepository
            )
        {
            _endpointRepository = endpointRepository;
        }

        public async Task<List<EndpointResultDto>> Execute()
        {
            List<EndpointResultDto> endpointResultList = (await _endpointRepository.GetAllEndpoints())
                .Select(x => new EndpointResultDto
                {
                    EndpointSerialNumber = x.EndpointSerialNumber,
                    MeterModelId = x.MeterModelId.ToString(),
                    MeterNumber = x.MeterNumber,
                    MeterFirmwareVersion = x.MeterFirmwareVersion,
                    SwitchState = x.SwitchState,
                })
                .ToList();

            return endpointResultList;
        }
    }
}
