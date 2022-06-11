using Boogops.Core;
using MongoDB.Driver;

namespace Boogops.MongoDbCore;

public class ThingDefStore<TThingDef> : Core.ThingDefStore<TThingDef>
    where TThingDef : ThingDef
{
    private readonly IMongoCollection<TThingDef> _thingDefsMongoCollection;

    public ThingDefStore(IGetThingDefsMongoCollection<TThingDef> getThingDefsMongoCollection)
    {
        _thingDefsMongoCollection = getThingDefsMongoCollection.Get();
    }

    public override async Task<BoogopsManagerResult> CreateAsync(TThingDef thingDef)
    {
        var retval = BoogopsManagerResult.Success;

        try
        {
            await _thingDefsMongoCollection.InsertOneAsync(thingDef);
        }
        catch (Exception e)
        {
            retval = BoogopsManagerResult.Failed(new BoogopsManagerError { Description = e.Message });
        }

        return retval;
    }
}