using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MakingAnOrder.Infrastructure.Database;
using MakingAnOrder.Infrastructure.Repositories;

namespace MakingAnOrder.Data.Repositories
{
    public class DapperRepository : IRepository
    {
        private readonly IDbContext dbContext;

        public DapperRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.GetAllAsync<TEntity>());
        }

        public async Task<TEntity> GetAsync<TEntity>(int id) where TEntity : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.GetAsync<TEntity>(id));
        }

        public async Task<int> InsertAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.InsertAsync(entity));
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await dbContext.PerformDbRequestAsync(db => db.UpdateAsync(entity));
        }

        public async Task DeleteAsync<TEntity>(int id) where TEntity : class
        {
            await dbContext.PerformDbRequest(async db =>
            {
                var entity = await db.GetAsync<TEntity>(id);
                await db.DeleteAsync(entity);
            });
        }

        public async Task ExecuteQueryAsync(string query, object paramModel = null)
        {
            await dbContext.PerformDbRequestAsync(db => db.QueryAsync(query, paramModel));
        }

        public async Task<IEnumerable<TEntity>> ExecuteQueryAsync<TEntity>(string query, object paramModel = null) where TEntity : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync<TEntity>(query, paramModel));
        }

        public async Task<TEntity> ExecuteQuerySingleAsync<TEntity>(string query, object paramModel = null) where TEntity : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QuerySingleAsync<TEntity>(query, paramModel));
        }

        public async Task<TAggregate> ExecuteAggregateQueryAsync<TAggregate>(string query, object paramModel = null)
        {
            return (await dbContext.PerformDbRequestAsync(db => db.QueryAsync<TAggregate>(query, paramModel))).FirstOrDefault();
        }

        public async Task ExecuteSPAsync(string spName, object paramModel = null)
        {
            await dbContext.PerformDbRequestAsync(db => db.QueryAsync(spName, paramModel, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<TEntity>> ExecuteSPAsync<TEntity>(string spName, object paramModel = null) where TEntity : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync<TEntity>(spName, paramModel, commandType: CommandType.StoredProcedure));
        }

        public async Task<TEntity> ExecuteSPSingleAsync<TEntity>(string spName, object paramModel = null) where TEntity : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryFirstOrDefaultAsync<TEntity>(spName, paramModel, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TReturn>(string spName, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TThird, TReturn>(string spName, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<TReturn>> ExecuteSPAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string spName, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(spName, map, splitOn: splitOn, param: paramModel, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(query, map, splitOn: splitOn, param: paramModel));
        }

        public async Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(query, map, splitOn: splitOn, param: paramModel));
        }

        public async Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(query, map, splitOn: splitOn, param: paramModel));
        }

        public async Task<IEnumerable<TReturn>> ExecuteQueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn, object paramModel = null)
            where TFirst : class
            where TSecond : class
            where TThird : class
            where TFourth : class
            where TFifth : class
            where TReturn : class
        {
            return await dbContext.PerformDbRequestAsync(db => db.QueryAsync(query, map, splitOn: splitOn, param: paramModel));
        }

        public void Dispose()
        {
        }
    }
}
