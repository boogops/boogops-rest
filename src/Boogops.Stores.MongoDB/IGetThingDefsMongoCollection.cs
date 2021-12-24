using MongoDB.Driver;

namespace Boogops.Stores.MongoDB;

public interface IGetThingDefsMongoCollection<TThingDef>
{
    IMongoCollection<TThingDef> Get();
}