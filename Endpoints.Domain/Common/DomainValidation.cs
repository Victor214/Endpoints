using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Domain.Common
{
    public static class DomainValidation
    {
        public static void ValidateProperty(object instance, string propertyName)
        {
            PropertyInfo prop = instance.GetType().GetProperty(propertyName);
            var propertyValue = prop.GetValue(instance);

            var context = new ValidationContext(instance)
            {
                MemberName = propertyName
            };
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(propertyValue, context, results);
            if (!isValid)
                throw new ValidationException($"The informed {propertyName} is not valid.");
        }

        public static void ValidateEnumExists<T>(object? key, string message)
        {
            bool isDefined = Enum.IsDefined(typeof(T), key);
            if (!isDefined)
                throw new ValidationException($"{message}");
        }
    }
}
