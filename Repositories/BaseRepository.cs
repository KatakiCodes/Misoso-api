using System;
using Microsoft.Data.SqlClient;

namespace Misoso.Api.Repositories;

public abstract class BaseRepository
{
    protected readonly SqlConnection _Connection;
    public BaseRepository(IConfiguration configuration)
    {
        _Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}
