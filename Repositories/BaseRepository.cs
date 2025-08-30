using Misoso.Api.Data;

namespace Misoso.Api.Repositories;

public abstract class BaseRepository
{
    protected readonly DataContext _Context;
    public BaseRepository(DataContext context)
    {
        _Context = context;
    }
}
