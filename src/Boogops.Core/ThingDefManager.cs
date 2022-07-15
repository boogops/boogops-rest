namespace Boogops.Core;

// public class ThingDefManager<TThingDef>
//     where TThingDef : class
// {
//     private readonly IThingDefStore<TThingDef> _thingDefStore;
//
//     public ThingDefManager(IThingDefStore<TThingDef> thingDefStore)
//     {
//         _thingDefStore = thingDefStore;
//     }
//
//     public virtual async Task<BoogopsManagerResult> CreateAsync(TThingDef thingDef)
//     {
//         var retval = await _thingDefStore.CreateAsync(thingDef);
//         return retval;
//     }
//
//     public virtual Task<TThingDef> FindByIdAsync(string thingDefId)
//     {
//         var retval = _thingDefStore.FindByIdAsync(thingDefId);
//         return retval;
//     }
// }