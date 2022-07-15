using MongoDB.Driver;

namespace Boogops.MongoDbCore;

public interface IGetThingDefsMongoCollection<TThingDef>
{
    IMongoCollectionFacade<TThingDef> Get();
}