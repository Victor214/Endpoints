using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Client.Commands.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EndpointDisplayAttribute : Attribute
    {
        public string Name { get; set; }
        public int TableMaxWidth { get; set; }
    }
}
