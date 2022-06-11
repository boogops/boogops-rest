using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.MongoDbCore;

internal class GetThingDefsMongoCollection<TThingDef> : IGetThingDefsMongoCollection<TThingDef>
{
    private const string COLLECTION = "ThingDefs";
    private readonly string _database;

    private readonly IMongoClient _mongoClient;

    public GetThingDefsMongoCollection(
        IOptions<StoreOptions> options,
        IGetMongoClient getMongoClient)
    {
        _database = options.Value.Database;
        _mongoClient = getMongoClient.Get();
    }

    public IMongoCollection<TThingDef> Get()
    {
        var database = _mongoClient.GetDatabase(_database);
        var retval = database.GetCollection<TThingDef>(COLLECTION);
        return retval;
    }
}