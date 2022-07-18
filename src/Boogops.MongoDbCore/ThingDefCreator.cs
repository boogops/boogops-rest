using Boogops.Core;

namespace Boogops.MongoDbCore;

public class ThingDefCreator<TThingDef> : ICreateThingDef<TThingDef>
    where TThingDef : ThingDef
{
    private readonly IMongoCollectionFacade<TThingDef> _thingDefsMongoCollection;

    public ThingDefCreator(IGetThingDefsMongoCollection<TThingDef> getThingDefsMongoCollection)
    {
        _thingDefsMongoCollection = getThingDefsMongoCollection.Get();
    }

    public async Task<BoogopsManagerResult> CreateAsync(TThingDef thingDef)
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