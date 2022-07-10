using Endpoints.Application.Endpoints.CreateEndpoint.Factory;
using Endpoints.Application.Endpoints.CreateEndpoint;
using Endpoints.Application.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Endpoints.Domain.Endpoints;
using Endpoints.Application.Endpoints.DeleteEndpoint;
using System.ComponentModel.DataAnnotations;

namespace Endpoints.Testing.Endpoints
{
    public class DeleteEndpointTests
    {
        [Fact]
        public async void Execute_WithExistingSerialNumber_DeletesEndpoint()
        {
            // Arrange
            var deleteEndpointModelStub = Mock.Of<DeleteEndpointModel>();

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.GetEndpointBySerialNumberAsync(It.IsAny<string?>()))
                .ReturnsAsync(Mock.Of<Endpoint>());

            // Act
            var deleteEndpoint = new DeleteEndpoint(repositoryStub.Object);
            Func<Task> execute = () => deleteEndpoint.Execute(deleteEndpointModelStub);

            // Assert
            var exception = await Record.ExceptionAsync(execute);
            Assert.Null(exception);
        }

        [Fact]
        public async void Execute_WithNonexistentSerialNumber_ThrowsValidationException()
        {
            // Arrange
            var deleteEndpointModelStub = Mock.Of<DeleteEndpointModel>();

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.GetEndpointBySerialNumberAsync(It.IsAny<string?>()))
                .ReturnsAsync((Endpoint?) null);

            // Act
            var deleteEndpoint = new DeleteEndpoint(repositoryStub.Object);
            Func<Task> execute = () => deleteEndpoint.Execute(deleteEndpointModelStub);

            // Assert
            await Assert.ThrowsAsync<ValidationException>(execute);
        }
    }
}
