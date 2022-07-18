using MongoDB.Driver;

namespace Boogops.MongoDbCore;

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