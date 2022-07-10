using Endpoints.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Domain.Common
{
    public class ExistsInEnumAttribute : ValidationAttribute
    {
        public Type Type { get; set; }
        public string Message { get; set; }

        public override bool IsValid(object value)
        {
            bool isDefined = Enum.IsDefined(Type, value);
            if (!isDefined)
                throw new ValidationException($"{Message}");
            return true;
        }
    }
}
