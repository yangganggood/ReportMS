﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Gear.Infrastructure.Storage.Builder;

namespace Gear.Infrastructure.Storage
{
    /// <summary>
    /// 使用 Dapper.NET 组件的储存容器基类
    /// </summary>
    public abstract class DapperStorage : StorageProvider
    {
        /// <summary>
        /// 获取第一个对象，若没有，则返回为 null
        /// </summary>
        /// <typeparam name="T">要查询的实体类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句
        /// 注：用具体的列名，不要使用 * 匹配符</param>
        /// <param name="param">查询参数</param>
        /// <returns><c>T</c></returns>
        public T SelectFirstOrDefault<T>(string sqlQuery, object param = null)
        {
            return this.Select<T>(sqlQuery, 1, 1, param).FirstOrDefault();
        }

        /// <summary>
        /// 获取在存储容器中的对象集合, 若没有数据，则返回空的集合（非 null）
        /// </summary>
        /// <typeparam name="T">要查询的实体类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句
        /// 注：用具体的列名，不要使用 * 匹配符</param>
        /// <param name="param">查询参数</param>
        /// <returns><c>T</c>集合</returns>
        public IEnumerable<T> Select<T>(string sqlQuery, object param = null)
        {
            return this.Connection.Query<T>(new CommandDefinition(sqlQuery, param));
        }

        public async Task<IEnumerable<T>> SelectAsync<T>(string sqlQuery, object param = null)
        {
            return await this.Connection.QueryAsync<T>(new CommandDefinition(sqlQuery, param));
        }

        /// <summary>
        /// 获取在存储容器中的对象集合, 若没有数据，则返回空的集合（非 null）
        /// </summary>
        /// <typeparam name="T">要查询的实体类型</typeparam>
        /// <param name="sqlQuery">SQL 查询语句
        /// 注：用具体的列名，不要使用 * 匹配符</param>
        /// <param name="start">分页起始数</param>
        /// <param name="count">每页的数量</param>
        /// <param name="param">查询参数</param>
        /// <returns><c>T</c>集合</returns>
        public IEnumerable<T> Select<T>(string sqlQuery, int start, int count, object param = null)
        {
            var sqlBuilder = new SqlSelectPagingClauseBuilder(sqlQuery, start, count);
            return this.Select<T>(sqlBuilder.ToString(), param);
        }

        /// <summary>
        /// 获取存储容器中的对象数量
        /// </summary>
        /// <param name="sqlQuery">SQL 查询语句
        /// 注：用具体的列名，不要使用 * 匹配符</param>
        /// <param name="param">查询参数</param>
        /// <returns><see cref="System.Int32"/></returns>
        public int GetRecordCount(string sqlQuery, object param = null)
        {
            var sqlBuilder = new SqlSelectCountClauseBuilder(sqlQuery);
            return this.Connection.ExecuteScalar<int>(sqlBuilder.ToString(), param);
        }

        public async Task<int> GetRecordCountAsync(string sqlQuery, object param = null)
        {
            var sqlBuilder = new SqlSelectCountClauseBuilder(sqlQuery);
            return await this.Connection.ExecuteScalarAsync<int>(sqlBuilder.ToString(), param);
        }

        /// <summary>
        /// 获取 DataReader 对象
        /// 在关闭 DataReader 时，也会同时关闭对数据库的连接
        /// </summary>
        /// <param name="sqlQuery">SQL 查询语句
        /// 注：用具体的列名，不要使用 * 匹配符</param>
        /// <param name="param">查询参数</param>
        /// <returns><see cref="System.Data.Common.DbDataReader"/></returns>
        public IDataReader GetDataReader(string sqlQuery, object param = null)
        {
            try
            {
                return this.Connection.ExecuteReader(new CommandDefinition(sqlQuery, param), CommandBehavior.CloseConnection);
            }
            catch
            {
                if (this.Connection != null)
                {
                    if (this.Connection.State != ConnectionState.Closed)
                        this.Connection.Close();
                }

                throw;
            }
        }

        public async Task<IDataReader> GetDataReaderAsync(string sqlQuery, object param = null)
        {
            try
            {
                return await this.Connection.ExecuteReaderAsync(new CommandDefinition(sqlQuery, param));
            }
            catch
            {
                if (this.Connection != null)
                {
                    if (this.Connection.State != ConnectionState.Closed)
                        this.Connection.Close();
                }

                throw;
            }
        }

        /// <summary>
        /// 获取 DataReader 对象
        /// 在关闭 DataReader 时，也会同时关闭对数据库的连接
        /// </summary>
        /// <param name="sqlQuery">SQL 查询语句
        /// 注：用具体的列名，不要使用 * 匹配符</param>
        /// <param name="start">分页起始数</param>
        /// <param name="count">每页的数量</param>
        /// <param name="param">查询参数</param>
        /// <returns><see cref="System.Data.Common.DbDataReader"/></returns>
        public IDataReader GetDataReader(string sqlQuery, int start, int count, object param = null)
        {
            var sqlBuilder = new SqlSelectPagingClauseBuilder(sqlQuery, start, count);
            return this.GetDataReader(sqlBuilder.ToString(), param);
        }
    }
}
