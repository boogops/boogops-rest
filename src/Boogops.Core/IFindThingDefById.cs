namespace Boogops.Core;

public interface IFindThingDefById<TThingDef>
    where TThingDef : class
{
    Task<TThingDef> FindByIdAsync(string thingDefId);
}