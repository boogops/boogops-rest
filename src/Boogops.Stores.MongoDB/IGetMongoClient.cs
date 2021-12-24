using MongoDB.Driver;

namespace Boogops.Stores.MongoDB;

public interface IGetMongoClient
{
    IMongoClient Get();
}