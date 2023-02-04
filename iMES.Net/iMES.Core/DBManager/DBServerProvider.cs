using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using iMES.Core.Configuration;
using iMES.Core.Const;
using iMES.Core.Dapper;
using iMES.Core.EFDbContext;
using iMES.Core.Enums;
using iMES.Core.Extensions;
using iMES.Entity.SystemModels;

namespace iMES.Core.DBManager
{
    public class DBServerProvider
    {
        private static readonly string _netcoredevserver = "netcoredevserver";
        private static readonly string _report = "report";
        private static Dictionary<string, string> ConnectionPool = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        { 
            //配置业务数据库连接  
            {_netcoredevserver, AppSetting.GetSettingString("ServiceConnectingString")},
            //配置报表数据库连接
            {_report, AppSetting.GetSettingString("ReportConnectingString")}
            //系统库不用配置了，已经在appsetting.json中配置过了
          };

        private static readonly string DefaultConnName = "default"; 

        static DBServerProvider()
        {
            SetConnection(DefaultConnName, AppSetting.DbConnectionString);
        }
        public static void SetConnection(string key, string val)
        {
            ConnectionPool[key] = val;
        }
        /// <summary>
        /// 设置默认数据库连接
        /// </summary>
        /// <param name="val"></param>
        public static void SetDefaultConnection(string val)
        {
            SetConnection(DefaultConnName, val);
        }

        public static string GetConnectionString(string key)
        {
            key = key ?? DefaultConnName;
            if (ConnectionPool.ContainsKey(key))
            {
                return ConnectionPool[key];
            }
            return key;
        }
        /// <summary>
        /// 获取默认数据库连接
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return GetConnectionString(DefaultConnName);
        }
        public static IDbConnection GetDbConnection(string connString = null)
        {
            if (connString == null)
            {
                connString = ConnectionPool[DefaultConnName];
            }
            if (DBType.Name == DbCurrentType.MySql.ToString())
            {
                return new MySql.Data.MySqlClient.MySqlConnection(connString);
            }
            if (DBType.Name == DbCurrentType.PgSql.ToString())
            {
                return new NpgsqlConnection(connString);
            }
            return new SqlConnection(connString);
        }


        /// <summary>
        /// 扩展dapper 获取MSSQL数据库DbConnection，默认系统获取配置文件的DBType数据库类型，
        /// </summary>
        /// <param name="connString">如果connString为null 执行重载GetDbConnection(string connString = null)</param>
        /// <param name="dapperType">指定连接数据库的类型：MySql/MsSql/PgSql</param>
        /// <returns></returns>
        public static IDbConnection GetDbConnection(string connString = null, DbCurrentType dbCurrentType = DbCurrentType.Default)
        {
            //默认获取DbConnection
            if (connString.IsNullOrEmpty() || DbCurrentType.Default == dbCurrentType)
            {
                return GetDbConnection(connString);
            }
            if (dbCurrentType == DbCurrentType.MySql)
            {
                return new MySql.Data.MySqlClient.MySqlConnection(connString);
            }
            if (dbCurrentType == DbCurrentType.PgSql)
            {
                return new NpgsqlConnection(connString);
            }
            return new SqlConnection(connString);

        }

        /// <summary>
        /// 获取系统库(2020.08.22)
        /// </summary>
        public static SysDbContext SysDbContext
        {
            get { return Utilities.HttpContext.Current.GetService<SysDbContext>(); ; }
        }

        /// <summary>
        /// 获取系统库(2020.08.22)
        /// </summary>
        public static SysDbContext DbContext
        {
            get { return GetEFDbContext(); }
        }
        /// <summary>
        /// 获取系统库(2020.08.22)
        /// </summary>
        public static SysDbContext GetEFDbContext()
        {
            return SysDbContext;
        }

        /// <summary>
        /// 获取业务库(2020.08.22)
        /// </summary>
        public static ServiceDbContext ServiceDbContext
        {
            get { return Utilities.HttpContext.Current.GetService<ServiceDbContext>(); ; }
        }

        /// <summary>
        /// 获取报表库(2020.08.22)
        /// </summary>
        public static ReportDbContext ReportDbContext
        {
            get { return Utilities.HttpContext.Current.GetService<ReportDbContext>(); ; }
        }


        /// <summary>
        /// 获取调用系统库的Dapper(2020.08.22)
        /// </summary>
        public static ISqlDapper SqlDapper
        {
            get
            {
                return new SqlDapper(DefaultConnName);
            }
        }

        /// <summary>
        /// 获取连接报表库的dapper(2020.08.22)
        /// </summary>
        public static ISqlDapper SqlDapperReport
        {
            get
            {
                return new SqlDapper(ReportConnectingString);
            }
        }

        /// <summary>
        /// 获取连接业务库的dapper(2020.08.22)
        /// </summary>
        public static ISqlDapper SqlDapperService
        {
            get
            {
                return new SqlDapper(ServiceConnectingString);
            }
        }

        /// <summary>
        /// 获取当前用户所属的业务库，需要添加存储用户所属数据库的字段(2020.08.22)
        /// </summary>
        public static ISqlDapper SqlDapperUserCurrentService
        {
            get
            {
                return new SqlDapper(ServiceUserCurrnetConnectingString);
            }
        }

        /// <summary>
        /// 默认获取连接系统库的dapper(2020.08.22)
        /// </summary>
        public static ISqlDapper GetSqlDapper(string dbName = null)
        {
            return new SqlDapper(dbName ?? DefaultConnName);
        }


        //(2020.08.22)
        public static ISqlDapper GetSqlDapper<TEntity>()
        {
            Type baseType = typeof(TEntity).BaseType;
            string dbName = null;
            if (baseType == typeof(SysEntity))
            {
                dbName = SysConnectingString;
            }
            else if (baseType == typeof(ServiceEntity))
            {
                dbName = ServiceConnectingString;
            }
            else if (baseType == typeof(ReportEntity))
            {
                dbName = ServiceConnectingString;
            }
            //获取实体真实的数据库连接池对象名，如果不存在则用默认数据连接池名
            //string dbName = typeof(TEntity).GetTypeCustomValue<DBConnectionAttribute>(x => x.DBName) ?? DefaultConnName;
            return GetSqlDapper(dbName);
        }

        /// <summary>
        /// 获取报表数据库的字符串连接(2020.08.22)
        /// </summary>
        public static string ReportConnectingString
        {
            //netcoredevserver为ConnectionPool字典中的key，如果字典中的key改变了，这里也要改变
            get { return GetDbConnectionString(_report); }
        }

        /// <summary>
        /// 获取业务库的字符串连接(2020.08.22)
        /// </summary>
        public static string ServiceConnectingString
        {
            //netcoredevserver为ConnectionPool字典中的key，如果字典中的key改变了，这里也要改变
            get { return GetDbConnectionString(_netcoredevserver); }
        }

        /// <summary>
        /// 获取业务库的字符串连接(2020.08.22)
        /// 获取当前用户所属的数据库连接，需要添加存储用户所属数据库的字段(2020.08.22)
        /// </summary>
        public static string ServiceUserCurrnetConnectingString
        {
            get
            {
                //UserContext.Current.DbName用户所属性数据库。需要自己添加字段
                // return ConnectionPool[UserContext.Current.DbName];
                return ServiceConnectingString;
            }
        }


        /// <summary>
        /// 获取系统库的字符串连接(2020.08.22)
        /// </summary>
        public static string SysConnectingString
        {
            get { return GetDbConnectionString(DefaultConnName); }
        }

        /// <summary>
        /// key为ConnectionPool初始化的所有数据库连接(2020.08.22)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetDbConnectionString(string key)
        {
            if (ConnectionPool.TryGetValue(key, out string connString))
            {
                return connString;
            }
            throw new Exception($"未配置[{key}]的数据库连接");
        }
        public static string GetContextName(string DBServer)
        {
            //  业务库
            if (DBServer == typeof(ServiceDbContext).Name)
            {
                return typeof(ServiceEntity).Name;
            }//报表库
            else if (DBServer == typeof(ReportDbContext).Name)
            {
                return typeof(ReportEntity).Name;
            }
            else//系统库
            {
                return typeof(SysEntity).Name;
            }
        }


    }
}
