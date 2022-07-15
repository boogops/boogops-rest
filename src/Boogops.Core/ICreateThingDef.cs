namespace Boogops.Core;

public interface ICreateThingDef<in TThingDef>
    where TThingDef : class
{
    Task<BoogopsManagerResult> CreateAsync(TThingDef thingDef);
}