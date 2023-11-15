using LMS.Core.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace LMS.Infra.Common;

public class DbContext : IDbContext
{
    private readonly IConfiguration _configuration;
    private IDbConnection _connection;
    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IDbConnection Connection
    {
        get
        {
            _connection = new OracleConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            return _connection;
        }
    }
}
