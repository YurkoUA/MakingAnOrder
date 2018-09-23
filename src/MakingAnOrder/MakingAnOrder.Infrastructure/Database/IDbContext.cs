using System;
using System.Data;

namespace MakingAnOrder.Infrastructure.Database
{
    public interface IDbContext
    {
        string ConnectionString { get; }

        void PerformDbRequest(Action<IDbConnection> action);
        TResult PerformDbRequest<TResult>(Func<IDbConnection, TResult> func);
    }
}
