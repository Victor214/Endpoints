using Endpoints.Domain.Endpoints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Endpoints.Testing.Endpoints
{
    public class DomainTests
    {
        // Meter Model Id
        [Fact]
        public void Endpoint_WithExistingMeterModelId_SetsMeterModelId()
        {
            Endpoint endpoint = new Endpoint();
            endpoint.MeterModelId = EModelId.NSX1P2W;
            Assert.Equal(EModelId.NSX1P2W, endpoint.MeterModelId);
        }

        [Fact]
        public void Endpoint_WithNonexistantMeterModelId_ThrowsValidationException()
        {
            Endpoint endpoint = new Endpoint();
            var execute = () =>
            {
                endpoint.MeterModelId = (EModelId)int.MaxValue;
                return;
            };
            Assert.Throws<ValidationException>(execute);
        }

        // SwitchState
        [Fact]
        public void Endpoint_WithExistingSwitchState_SetsSwitchState()
        {
            Endpoint endpoint = new Endpoint();
            endpoint.SwitchState = ESwitchState.Disconnected;
            Assert.Equal(ESwitchState.Disconnected, endpoint.SwitchState);
        }

        [Fact]
        public void Endpoint_WithNonexistantSwitchState_ThrowsValidationException()
        {
            Endpoint endpoint = new Endpoint();
            var execute = () =>
            {
                endpoint.SwitchState = (ESwitchState)int.MaxValue;
                return;
            };
            Assert.Throws<ValidationException>(execute);
        }
    }
}
