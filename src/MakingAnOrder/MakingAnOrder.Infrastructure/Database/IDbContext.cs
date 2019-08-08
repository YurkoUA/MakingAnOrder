using System;
using System.Data;
using System.Threading.Tasks;

namespace MakingAnOrder.Infrastructure.Database
{
    public interface IDbContext
    {
        string ConnectionString { get; }

        void PerformDbRequest(Action<IDbConnection> action);
        TResult PerformDbRequest<TResult>(Func<IDbConnection, TResult> func);

        Task PerformDbRequestAsync(Func<IDbConnection, Task> action);
        Task<TResult> PerformDbRequestAsync<TResult>(Func<IDbConnection, Task<TResult>> func);
    }
}
