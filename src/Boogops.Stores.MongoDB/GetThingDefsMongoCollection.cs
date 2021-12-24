using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MongoDB.Driver;

namespace Boogops.Stores.MongoDB;

internal class GetThingDefsMongoCollection<TThingDef> : IGetThingDefsMongoCollection<TThingDef>
{
    private const string COLLECTION = "ThingDefs";
    
    private readonly IMongoClient _mongoClient;
    private readonly string _database;

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