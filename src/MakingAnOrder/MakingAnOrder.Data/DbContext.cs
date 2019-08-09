using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MakingAnOrder.Infrastructure.Database;

namespace MakingAnOrder.Data
{
    public class DbContext : IDbContext
    {
        public DbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }

        public void PerformDbRequest(Action<IDbConnection> action)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                action(db);
            }
        }

        public TResult PerformDbRequest<TResult>(Func<IDbConnection, TResult> func)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return func(db);
            }
        }

        public async Task PerformDbRequestAsync(Func<IDbConnection, Task> action)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                await action(db);
            }
        }

        public async Task<TResult> PerformDbRequestAsync<TResult>(Func<IDbConnection, Task<TResult>> func)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return await func(db);
            }
        }
    }
}
