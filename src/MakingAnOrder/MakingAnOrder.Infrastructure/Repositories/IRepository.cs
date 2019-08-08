using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakingAnOrder.Infrastructure.Repositories
{
    public interface IRepository : IDisposable
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        Task<TEntity> GetAsync<TEntity>(int id) where TEntity : class;

        Task<int> InsertAsync<TEntity>(TEntity entity) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity>(int id) where TEntity : class;

        Task ExecuteQueryAsync(string query, object paramModel = null);
        Task<IEnumerable<TEntity>> ExecuteQueryAsync<TEntity>(string query, object paramModel = null) where TEntity : class;
        Task<TEntity> ExecuteQuerySingleAsync<TEntity>(string query, object paramModel = null) where TEntity : class;

        Task<TAggregate> ExecuteAggregateQueryAsync<TAggregate>(string query, object paramModel = null);

        Task ExecuteSPAsync(string spName, object paramModel = null);
        Task<IEnumerable<TEntity>> ExecuteSPAsync<TEntity>(string spName, object paramModel = null) where TEntity : class;
        Task<TEntity> ExecuteSPSingleAsync<TEntity>(string spName, object paramModel = null) where TEntity : class;

        Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TReturn>(string spName, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TThird, TReturn>(string spName, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class;

        Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class;
    }
}
