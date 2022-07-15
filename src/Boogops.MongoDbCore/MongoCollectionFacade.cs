using MongoDB.Driver;

namespace Boogops.MongoDbCore;

public class MongoCollectionFacade<T> : IMongoCollectionFacade<T>
{
    private readonly IMongoCollection<T> _collection;
    
    public MongoCollectionFacade(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public Task InsertOneAsync(T document)
    {
        return _collection.InsertOneAsync(document);
    }

    public IFindFluentFacade<T> Find(FilterDefinition<T> filterDefinition)
    {
        var findFluent = _collection.Find(filterDefinition);
        var retval = new FindFluentFacade<T>(findFluent);
        return retval;
    }
}

public class FindFluentFacade<T> : IFindFluentFacade<T>
{
    private readonly IFindFluent<T, T> _findFluent;

    public FindFluentFacade(IFindFluent<T, T> findFluent)
    {
        _findFluent = findFluent;
    }

    public Task<T> SingleAsync()
    {
        return _findFluent.SingleAsync();
    }
}