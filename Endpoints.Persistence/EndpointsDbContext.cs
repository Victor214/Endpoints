using Endpoints.Domain.Endpoints;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Persistence
{
    public class EndpointsDbContext : DbContext
    {
        public EndpointsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Endpoint> Endpoints { get; set; }

    }
}
