namespace Boogops.Core;

public interface IThingDefStore<TThingDef>
    where TThingDef : class
{
    Task<BoogopsManagerResult> CreateAsync(TThingDef thingDef);
}