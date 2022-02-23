using Lp.Framework.Extensions.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lp.Framework.HttpService
{
    public static class HttpClientExtensions
    {
        private static IHttpClientFactory httpClientFactory = null!;

        public static void Configure(IApplicationBuilder app)
        {
        }

        public static IApplicationBuilder UseHttpClient(this IApplicationBuilder app)
        {
            httpClientFactory = app.ApplicationServices.GetService<IHttpClientFactory>() ??
                throw new ArgumentNullException("IHttpClientFactory", "引入异常");

            return app;
        }

        public static async Task<T?> Request<T>(this string url, HttpMethod httpMethod)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            var client = httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result.ToObject<T>();
            }

            return default(T);
        }
    }
}