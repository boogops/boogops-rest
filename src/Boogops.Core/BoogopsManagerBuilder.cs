using Microsoft.Extensions.DependencyInjection;

namespace Boogops.Core;

public class BoogopsManagerBuilder
{
    public BoogopsManagerBuilder(
        Type thingDefType,
        IServiceCollection services)
    {
        ThingDefType = thingDefType;
        Services = services;
    }

    public Type ThingDefType { get; }

    public IServiceCollection Services { get; }
}