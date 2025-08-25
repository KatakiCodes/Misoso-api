using System;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace Misoso.Api.Repositories;

public abstract class BaseRepository
{
    protected readonly NpgsqlConnection _Connection;
    public BaseRepository(IConfiguration configuration)
    {
        _Connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}
