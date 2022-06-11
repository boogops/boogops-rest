namespace Boogops.Core;

public abstract class ThingDefStore<TThingDef> : IThingDefStore<TThingDef>
    where TThingDef : ThingDef
{
    public abstract Task<BoogopsManagerResult> CreateAsync(TThingDef thingDef);
}