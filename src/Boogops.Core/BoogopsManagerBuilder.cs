using Microsoft.Extensions.DependencyInjection;

namespace Boogops.Core;

public class BoogopsManagerBuilder
{
    public BoogopsManagerBuilder(Type thingType, IServiceCollection services)
    {
        ThingType = thingType;
        Services = services;
    }

    public Type ThingType { get; }
    public IServiceCollection Services { get; }
}