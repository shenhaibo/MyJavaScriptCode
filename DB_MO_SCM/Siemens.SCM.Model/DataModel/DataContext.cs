using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Siemens.SCM.Model.DataModel
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<DefaultData> DefaultDatas { get; set; }
        public DbSet<DefaultDataType> DefaultDataTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //配置默认数据与默认数据类型关系
            modelBuilder.Entity<DefaultData>().HasRequired<DefaultDataType>(p => p.defaultDataType);
            base.OnModelCreating(modelBuilder);
        }
    }
}
