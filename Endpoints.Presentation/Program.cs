using Endpoints.Application.Endpoints.CreateEndpoint;
using Endpoints.Application.Endpoints.EditEndpoint;
using Endpoints.Application.Endpoints.FindEndpoint;
using Endpoints.Application.Interfaces;
using Endpoints.Persistence;
using Endpoints.Persistence.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add database configuration
builder.Services.AddDbContext<EndpointsDbContext>(opt => opt.UseInMemoryDatabase("EndpointsDb"));
builder.Services.AddScoped<IEndpointRepository, EndpointRepository>();

// Add services to container
builder.Services.AddScoped<ICreateEndpoint, CreateEndpoint>();
builder.Services.AddScoped<IEditEndpoint, EditEndpoint>();
builder.Services.AddScoped<IFindEndpoint, FindEndpoint>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();