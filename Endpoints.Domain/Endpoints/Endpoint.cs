using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Domain.Endpoints
{
    public class Endpoint : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 16, MinimumLength = 1)]
        public string? EndpointSerialNumber { get; set; }

        [Required]
        public EModelId MeterModelId { get; set; }

        [Required]
        public int MeterNumber { get; set; }

        [Required]
        [StringLength(maximumLength: 16, MinimumLength = 1)]
        public string? MeterFirmwareVersion { get; set; }

        [Required]
        public ESwitchState SwitchState { get; set; }

        public Endpoint()
        { 

        }

        public Endpoint(string? endpointSerialNumber, string? meterModelId, int meterNumber, string? meterFirmwareVersion, int switchState)
        {
            ValidateExistingMeterModelId(meterModelId);
            ValidateExistingSwitchState(switchState);

            EndpointSerialNumber = endpointSerialNumber;
            MeterModelId = Enum.Parse<EModelId>(meterModelId);
            MeterNumber = meterNumber;
            MeterFirmwareVersion = meterFirmwareVersion;
            SwitchState = (ESwitchState) switchState;

            Validate(); // Run last to make sure all properties are set beforehand.
        }

        public void SetSwitchState(int switchState)
        {
            ValidateExistingSwitchState(switchState);
            SwitchState = (ESwitchState)switchState;
            Validate();
        }

        private void ValidateExistingMeterModelId(string? meterModelId)
        {
            bool isDefined = Enum.IsDefined(typeof(EModelId), meterModelId);
            if (!isDefined)
                throw new ValidationException("The informed Meter Model Id does not exist.");
        }

        private void ValidateExistingSwitchState(int switchState)
        {
            bool isDefined = Enum.IsDefined(typeof(ESwitchState), switchState);
            if (!isDefined)
                throw new ValidationException("The informed Switch State is not valid.");
        }

        private void Validate()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);
            if (!isValid)
            {
                var invalidMember = results
                    .FirstOrDefault()?
                    .MemberNames
                    .FirstOrDefault();

                if (invalidMember != null)
                    throw new ValidationException($"The informed {invalidMember} is not valid.");
                throw new Exception();
            }
        }
    }
}
