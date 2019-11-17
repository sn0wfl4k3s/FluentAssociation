using Microsoft.Extensions.DependencyInjection;

namespace FluentAssociation
{
    public static class FluentAssociationBuilderExtension
    {
        public static void AddFluentAssociation(this IServiceCollection services)
        {
            services.AddTransient(typeof(IFluentAssociation<>), typeof(FluentAssociation<>));
        }
    }
}