using FluentAssociation.Library.Implementation;
using FluentAssociation.Library.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FluentAssociation.Library.Configuration
{
    public static class FluentAssociationBuilderExtension
    {
        public static void AddFluentAssociation(this IServiceCollection services)
        {
            services.AddTransient(typeof(IFluentAssociation<>), typeof(FluentAssociation<>));
        }
    }
}