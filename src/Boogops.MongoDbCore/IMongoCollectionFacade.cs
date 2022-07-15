using MongoDB.Driver;

namespace Boogops.MongoDbCore;

public interface IMongoCollectionFacade<T>
{
    Task InsertOneAsync(T document);

    IFindFluentFacade<T> Find(FilterDefinition<T> filterDefinition);
}

public interface IFindFluentFacade<T>
{
    Task<T> SingleAsync();
}