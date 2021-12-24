using Boogops.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Boogops.Stores.MongoDB.Extensions.DependencyInjection;

public static class DocumentManagerBuilderExtensions
{
    public static BoogopsManagerBuilder AddMongoStore(
        this BoogopsManagerBuilder builder,
        Action<StoreOptions> configureOptions = null)
    {
        if (configureOptions != null) builder.Services.Configure(configureOptions);
        builder.Services.AddScoped<IGetMongoClient, GetMongoClient>();
        builder.Services.AddScoped(typeof(IGetThingDefsMongoCollection<>).MakeGenericType(builder.ThingDefType),
            typeof(GetThingDefsMongoCollection<>).MakeGenericType(builder.ThingDefType));
        builder.Services.AddScoped(typeof(IThingDefStore<>).MakeGenericType(builder.ThingDefType),
            typeof(ThingDefStore<>).MakeGenericType(builder.ThingDefType));
        return builder;
    }
}