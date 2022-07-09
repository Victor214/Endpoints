﻿using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Application.Interfaces
{
    public interface IEndpointRepository
    {
        Task CreateAsync(Endpoint endpoint);
        Task<Endpoint?> GetEndpointBySerialNumberAsync(string? endpointSerialNumber);
        Task SaveAsync();
    }
}
