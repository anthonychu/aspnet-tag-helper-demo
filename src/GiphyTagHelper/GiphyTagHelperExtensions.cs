using Microsoft.Extensions.DependencyInjection;

namespace GiphyTagHelper
{
    public static class GiphyTagHelperExtensions
    {
        public static void AddGiphyTagHelper (this IServiceCollection services, GiphyTagHelperConfiguration config)
        {
            services.AddSingleton(_ => config);
        }
    }
}
