using Endpoints.Client.Commands.Attributes;
using Endpoints.Client.Commands.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Client.Commands.Extensions
{
    public static class EndpointOutputExtensions
    {
        private static EndpointDisplayAttribute? GetEndpointDisplayAttribute(string propertyName)
        {
            var t = typeof(EndpointOutput)
                .GetProperty(propertyName)?
                .GetCustomAttributes(false)
                .OfType<EndpointDisplayAttribute>()
                .FirstOrDefault();

            return t;
        }

        public static string? GetName(this EndpointOutput endpointOutput, string propertyName)
        {
            EndpointDisplayAttribute? displayAttribute = GetEndpointDisplayAttribute(propertyName);
            return displayAttribute?.Name;
        }

        public static int? GetTableMaxWidth(this EndpointOutput endpointOutput, string propertyName)
        {
            EndpointDisplayAttribute? displayAttribute = GetEndpointDisplayAttribute(propertyName);
            return displayAttribute?.TableMaxWidth;
        }
    }
}
