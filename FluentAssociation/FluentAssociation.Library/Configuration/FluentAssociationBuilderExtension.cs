using Microsoft.Extensions.DependencyInjection;

namespace FluentAssociation
{
    public static class FluentAssociationBuilderExtension
    {
        public static void AddFluentAssociation<T>(this IServiceCollection services)
        {
            services.AddTransient(typeof(IFluentAssociation<T>), typeof(FluentAssociation<T>));
        }
    }
}