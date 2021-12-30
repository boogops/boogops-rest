using Boogops.Core;

namespace Boogops.Stores;

public abstract class ThingDefStore<TThingDef> : IThingDefStore<TThingDef>
    where TThingDef : ThingDef
{
    public abstract Task<BoogopsManagerResult> CreateAsync(TThingDef thingDef);
}