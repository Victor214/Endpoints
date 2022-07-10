using Endpoints.Application.Endpoints.CreateEndpoint;
using Endpoints.Application.Endpoints.CreateEndpoint.Factory;
using Endpoints.Application.Endpoints.DeleteEndpoint;
using Endpoints.Application.Endpoints.EditEndpoint;
using Endpoints.Application.Endpoints.FindEndpoint;
using Endpoints.Application.Endpoints.ListEndpoint;
using Endpoints.Application.Interfaces;
using Endpoints.Persistence;
using Endpoints.Persistence.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Core configuration
builder.Services.AddDbContext<EndpointsDbContext>(opt => opt.UseInMemoryDatabase("EndpointsDb"));
builder.Services.AddScoped<IEndpointRepository, EndpointRepository>();
builder.Services.AddScoped<IEndpointFactory, EndpointFactory>();

// Add operation services to container
builder.Services.AddScoped<ICreateEndpoint, CreateEndpoint>();
builder.Services.AddScoped<IEditEndpoint, EditEndpoint>();
builder.Services.AddScoped<IDeleteEndpoint, DeleteEndpoint>();
builder.Services.AddScoped<IFindEndpoint, FindEndpoint>();
builder.Services.AddScoped<IListEndpoint, ListEndpoint>();


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