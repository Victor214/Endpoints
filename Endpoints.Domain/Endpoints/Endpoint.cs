using Endpoints.Domain.Common;
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
        public string? EndpointSerialNumber
        {
            get { return _endpointSerialNumber; }
            set
            {
                _endpointSerialNumber = value;
                DomainValidation.ValidateProperty(this, nameof(EndpointSerialNumber));
            }
        }
        private string? _endpointSerialNumber;

        [Required]
        [ExistsInEnum(Type = typeof(EModelId), Message = "The informed Meter Model Id does not exist.")]
        public EModelId MeterModelId
        { 
            get { return _meterModelId; }
            set
            { 
                _meterModelId = value;
                DomainValidation.ValidateProperty(this, nameof(MeterModelId));
            }
        }
        private EModelId _meterModelId;


        [Required]
        public int MeterNumber
        {
            get { return _meterNumber; }
            set
            {
                _meterNumber = value;
                DomainValidation.ValidateProperty(this, nameof(MeterNumber));
            }
        }
        private int _meterNumber;


        [Required]
        [StringLength(maximumLength: 16, MinimumLength = 1)]
        public string? MeterFirmwareVersion
        {
            get { return _meterFirmwareVersion; }
            set
            {
                _meterFirmwareVersion = value;
                DomainValidation.ValidateProperty(this, nameof(MeterFirmwareVersion));
            }
        }
        private string? _meterFirmwareVersion;


        [Required]
        [ExistsInEnum(Type = typeof(ESwitchState), Message = "The informed Switch State is not valid.")]
        public ESwitchState SwitchState
        {
            get { return _switchState; }
            set
            {
                _switchState = value;
                DomainValidation.ValidateProperty(this, nameof(SwitchState));
            }
        }
        private ESwitchState _switchState;




        public virtual void SetSwitchState(int switchState)
        {
            SwitchState = (ESwitchState) switchState;
        }

        public virtual void SetMeterModelId(string? meterModelId)
        {
            DomainValidation.ValidateEnumExists<EModelId>(meterModelId, "The informed Meter Model Id does not exist.");
            MeterModelId = Enum.Parse<EModelId>(meterModelId);
        }
    }
}
