using MongoDB.Driver;

namespace Boogops.MongoDbCore;

public interface IGetThingDefsMongoCollection<TThingDef>
{
    IMongoCollection<TThingDef> Get();
}