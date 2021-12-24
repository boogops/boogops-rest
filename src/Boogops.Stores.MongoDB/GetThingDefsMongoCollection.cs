using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boogops.Stores.MongoDB;

internal class GetThingDefsMongoCollection<TThingDef> : IGetThingDefsMongoCollection<TThingDef>
{
    private readonly IMongoClient _mongoClient;
    private readonly string _database;
    private readonly string _collection;

    public GetThingDefsMongoCollection(
        IOptions<StoreOptions> options, 
        IGetMongoClient getMongoClient)
    {
        _database = options.Value.Database;
        _collection = options.Value.Collection;
        _mongoClient = getMongoClient.Get();
    }

    public IMongoCollection<TThingDef> Get()
    {
        var database = _mongoClient.GetDatabase(_database);
        var retval = database.GetCollection<TThingDef>(_collection);
        return retval;
    }
}