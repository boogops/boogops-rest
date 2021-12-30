using Microsoft.Extensions.DependencyInjection;

namespace Boogops.Core.Extensions.DependencyInjection;

public static class BoogopsManagerServiceCollectionExtensions
{
    public static BoogopsManagerBuilder AddBoogopsManager<TThingDef>(
        this IServiceCollection services)
        where TThingDef : class
    {
        services.AddScoped<ThingDefManager<TThingDef>>();
        return new BoogopsManagerBuilder(typeof(TThingDef), services);
    }
}