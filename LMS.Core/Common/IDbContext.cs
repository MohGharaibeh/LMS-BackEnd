using System.Data;
namespace LMS.Core.Common;

public interface IDbContext
{
    public IDbConnection Connection { get; }
}
