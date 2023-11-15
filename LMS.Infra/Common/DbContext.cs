using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace LMS.Infra.Common;

public class DbContext
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
            _connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            return _connection;
        }
    }
}
