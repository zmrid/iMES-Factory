using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using iMES.Core.Extensions;

namespace iMES.Core.EFDbContext
{
    public abstract class BaseDbContext : DbContext
    {
        protected abstract string ConnectionString { get; }

        public bool QueryTracking
        {
            set
            {
                this.ChangeTracker.QueryTrackingBehavior = value ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;
            }
        }
        public BaseDbContext() : base() { }
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        protected void UseDbType(DbContextOptionsBuilder optionsBuilder,string connectionString)
        {
            if (Const.DBType.Name == Enums.DbCurrentType.MySql.ToString())
            {
                optionsBuilder.UseMySql(connectionString);
            }
            else if (Const.DBType.Name == Enums.DbCurrentType.PgSql.ToString())
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected void OnModelCreating(ModelBuilder modelBuilder, Type type)
        {
            try
            {
                //获取所有类库
                var compilationLibrary = DependencyContext
                    .Default
                    .CompileLibraries
                    .Where(x => !x.Serviceable && x.Type != "package" && x.Type == "project");
                foreach (var _compilation in compilationLibrary)
                {
                    //加载指定类
                    AssemblyLoadContext.Default
                    .LoadFromAssemblyName(new AssemblyName(_compilation.Name))
                    .GetTypes().Where(x => x.GetTypeInfo().BaseType != null
                    && x.BaseType == (type)).ToList()
                    .ForEach(t => { modelBuilder.Entity(t); });
                }
                base.OnModelCreating(modelBuilder);
            }
            catch (Exception ex)
            {
                string mapPath = ($"Log/").MapPath();
                Utilities.FileHelper.WriteFile(mapPath, $"syslog_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt", ex.Message + ex.StackTrace + ex.Source);
            }

        }

    }
}
