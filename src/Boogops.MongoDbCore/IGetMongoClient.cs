using MongoDB.Driver;

namespace Boogops.MongoDbCore;

public interface IGetMongoClient
{
    IMongoClient Get();
}