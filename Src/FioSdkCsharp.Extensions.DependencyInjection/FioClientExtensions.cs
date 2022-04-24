using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FioSdkCsharp.Extensions.DependencyInjection
{
    public static class FioClientExtensions
    {
        /// <summary>
        /// Register HTTP Client for Fio
        /// </summary>
        public static IServiceCollection AddFioClient(this IServiceCollection services, string authToken)
        {
            services.PostConfigure<FioClientExtensionsOptions>(options =>
            {
                options.AuthToken = authToken;
            });

            services.AddHttpClient<IFioClient, FioClient>(client =>
            {
                client.DefaultRequestHeaders.Add("SrcLibrary", "nuget.org/fiosdk");
            });

            services.AddScoped<FioClientConfiguration>(x => x.GetRequiredService<IOptions<FioClientExtensionsOptions>>().Value);

            return services;
        }
    }
}