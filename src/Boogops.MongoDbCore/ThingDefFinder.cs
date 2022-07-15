using Boogops.Core;
using MongoDB.Driver;

namespace Boogops.MongoDbCore;

public class ThingDefFinder<TThingDef> : IFindThingDefById<TThingDef>
    where TThingDef : ThingDef
{
    private readonly IMongoCollectionFacade<TThingDef> _thingDefsMongoCollection;

    public ThingDefFinder(IGetThingDefsMongoCollection<TThingDef> getThingDefsMongoCollection)
    {
        _thingDefsMongoCollection = getThingDefsMongoCollection.Get();
    }

    public async Task<TThingDef> FindByIdAsync(string thingDefId)
    {
        var filter = Builders<TThingDef>.Filter.Eq(x => x.Id, thingDefId);
        var retval = await _thingDefsMongoCollection.Find(filter)
            .SingleAsync();
        return retval;
    }
}