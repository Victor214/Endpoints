using Endpoints.Application.Endpoints.Common;
using Endpoints.Application.Endpoints.DeleteEndpoint;
using Endpoints.Application.Endpoints.FindEndpoint;
using Endpoints.Application.Interfaces;
using Endpoints.Domain.Endpoints;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Endpoints.Testing.Endpoints
{
    public class FindEndpointTests
    {
        [Fact]
        public async void Execute_WithExistingSerialNumber_FindsEndpoint()
        {
            // Arrange
            var findEndpointModelStub = Mock.Of<FindEndpointModel>();

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.GetEndpointBySerialNumberAsync(It.IsAny<string?>()))
                .ReturnsAsync(Mock.Of<Endpoint>());

            // Act
            var findEndpoint = new FindEndpoint(repositoryStub.Object);
            var result = await findEndpoint.Execute(findEndpointModelStub);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EndpointResultDto?>(result);
        }

        [Fact]
        public async void Execute_WithNonexistentSerialNumber_ThrowsValidationException()
        {
            // Arrange
            var findEndpointModelStub = Mock.Of<FindEndpointModel>();

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.GetEndpointBySerialNumberAsync(It.IsAny<string?>()))
                .ReturnsAsync((Endpoint?) null);

            // Act
            var findEndpoint = new FindEndpoint(repositoryStub.Object);
            Func<Task> execute = () => findEndpoint.Execute(findEndpointModelStub);

            // Assert
            await Assert.ThrowsAsync<ValidationException>(execute);
        }
    }
}
