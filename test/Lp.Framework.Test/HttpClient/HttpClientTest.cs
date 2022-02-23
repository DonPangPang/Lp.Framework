using Lp.Framework.HttpService;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lp.Framework.Test.HttpClient
{
    public class HttpClientTest
    {
        [Fact]
        public void Test1()
        {
            IServiceCollection services = null!;
            IApplicationBuilder app = null!;

            services.AddHttpClient();
            app.UseHttpClient();
        }
    }
}