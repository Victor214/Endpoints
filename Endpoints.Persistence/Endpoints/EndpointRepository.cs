using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using Endpoints.Application.Interfaces;
using Endpoints.Domain.Endpoints;
using Microsoft.EntityFrameworkCore;

namespace Endpoints.Persistence.Endpoints
{
    public class EndpointRepository : IEndpointRepository
    {
        private EndpointsDbContext _context;

        public EndpointRepository(
            EndpointsDbContext context
            )
        {
            _context = context;
        }

        public void Create(Endpoint endpoint)
        {

            _context.Endpoints.Add(endpoint);
        }

        public void Update(Endpoint endpoint)
        {
            _context.Endpoints.Update(endpoint);
        }

        public void Delete(Endpoint endpoint)
        {
            _context.Endpoints.Remove(endpoint);
        }

        public async Task<bool> SerialNumberExists(string? endpointSerialNumber)
        {
            return await _context.Endpoints.AnyAsync(x => x.EndpointSerialNumber == endpointSerialNumber);
        }

        public async Task<Endpoint?> GetEndpointBySerialNumberAsync(string? endpointSerialNumber)
        {
            var endpoint = await _context.Endpoints.FirstOrDefaultAsync(x => x.EndpointSerialNumber == endpointSerialNumber);
            return endpoint;
        }

        public async Task<List<Endpoint>?> GetAllEndpoints()
        {
            var endpoints = await _context.Endpoints.ToListAsync();
            return endpoints;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}