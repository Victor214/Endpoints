using Endpoints.Application.Endpoints.DeleteEndpoint;
using Endpoints.Application.Endpoints.EditEndpoint;
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
    public class EditEndpointTests
    {
        [Fact]
        public async void Execute_WithExistingSerialNumber_EditsEndpoint()
        {
            // Arrange
            var editEndpointModelStub = Mock.Of<EditEndpointModel>();

            var resultEndpointStub = new Mock<Endpoint>();
            resultEndpointStub.Setup(x => x.SetSwitchState(It.IsAny<int>()));

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.GetEndpointBySerialNumberAsync(It.IsAny<string?>()))
                .ReturnsAsync(resultEndpointStub.Object);

            // Act
            var editEndpoint = new EditEndpoint(repositoryStub.Object);
            Func<Task> execute = () => editEndpoint.Execute(editEndpointModelStub);

            // Assert
            var exception = await Record.ExceptionAsync(execute);
            Assert.Null(exception);
        }

        [Fact]
        public async void Execute_WithNonexistentSerialNumber_ThrowsValidationException()
        {
            // Arrange
            var editEndpointModelStub = Mock.Of<EditEndpointModel>();

            var repositoryStub = new Mock<IEndpointRepository>();
            repositoryStub.Setup(x => x.GetEndpointBySerialNumberAsync(It.IsAny<string?>()))
                .ReturnsAsync((Endpoint?) null);

            // Act
            var editEndpoint = new EditEndpoint(repositoryStub.Object);
            Func<Task> execute = () => editEndpoint.Execute(editEndpointModelStub);

            // Assert
            await Assert.ThrowsAsync<ValidationException>(execute);
        }
    }
}
