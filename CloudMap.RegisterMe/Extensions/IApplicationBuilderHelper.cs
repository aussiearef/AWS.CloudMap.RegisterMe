using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CloudMap.RegisterMe.Extensions
{
    public static class ApplicationBuilderHelper
    {
        public static void UseCustomCloudMapClient<T>(this IServiceCollection collection) where T: class, ICloudMapClient
        {
            collection.AddSingleton<ICloudMapClient, T>();
        }

        public static async Task RegisterWithCloudMap(this IApplicationBuilder app, CloudMapRegistrationOptions options)
        {
            var customClient = app.ApplicationServices.GetService(typeof(ICloudMapClient)) as ICloudMapClient;
            var client = customClient ?? new CloudMapClient();
            if (options == null || string.IsNullOrEmpty(options.ServiceId))
                throw new ArgumentException("Options must not be null and ServiceId must be provided.");

            if (string.IsNullOrEmpty(options.InstanceId))
                await client.RegisterEc2Async(options.ServiceId, options.Port);
            else
                await client.RegisterEc2Async(options.ServiceId, options.InstanceId, options.Port);
        }
    }
}