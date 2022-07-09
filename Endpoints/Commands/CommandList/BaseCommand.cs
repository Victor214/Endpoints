using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Endpoints.Commands.CommandList
{
    public abstract class BaseCommand
    {
        public abstract string BaseText { get; }
        protected abstract string Instructions { get; }
        protected HttpClient Client { get; set; } = new HttpClient();
        public abstract Task ExecuteAsync();

        public BaseCommand()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        }
    }
}
