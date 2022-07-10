using Endpoints.Application.Interfaces;
using Endpoints.Application.Endpoints.CreateEndpoint;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Endpoints.Application.Endpoints.CreateEndpoint.Factory;
using Endpoints.Domain.Endpoints;
using System.ComponentModel.DataAnnotations;

namespace Endpoints.Testing.Endpoints.CreateEndpointTests
{
    public class CreateEndpointTests
    {

        [Fact]
        public async void Execute_WithUniqueSerialNumber_CreatesEndpoint()
        {
            // Arrange
            var createEndpointModelStub = Mock.Of<CreateEndpointModel>();

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.SerialNumberExists(It.IsAny<string?>()))
                .ReturnsAsync(false);

            var factoryStub = new Mock<IEndpointFactory>();
            factoryStub.Setup(x => x.Create(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<int>()))
                .Returns(Mock.Of<Endpoint>());

            // Act
            var createEndpoint = new CreateEndpoint(repositoryStub.Object, factoryStub.Object);
            Func<Task> execute = () => createEndpoint.Execute(createEndpointModelStub);

            // Assert
            var exception = await Record.ExceptionAsync(execute);
            Assert.Null(exception);
        }

        [Fact]
        public async void Execute_WithRepeatedSerialNumber_ThrowsValidationException()
        {
            // Arrange
            var createEndpointModelStub = Mock.Of<CreateEndpointModel>();

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.SerialNumberExists(It.IsAny<string?>()))
                .ReturnsAsync(true);

            var factoryStub = new Mock<IEndpointFactory>();
            factoryStub.Setup(x => x.Create(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<int>(), It.IsAny<string?>(), It.IsAny<int>()))
                .Returns(Mock.Of<Endpoint>());

            // Act
            var createEndpoint = new CreateEndpoint(repositoryStub.Object, factoryStub.Object);
            Func<Task> execute = () => createEndpoint.Execute(createEndpointModelStub);

            // Assert
            await Assert.ThrowsAsync<ValidationException>(execute);
        }
    }
}
