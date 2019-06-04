using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.EntityFrameworkCore;
namespace chatick.DataBase_Classes
{
    class AppDatabase : DbContext
    {
        //private readonly string schema;

        //public AppDatabase(string schema)
        //  : base("AppDatabaseConnectionString")
        //{
        //    this.schema = schema;
        //}

        //public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(DBM builder)
        //{
        //    builder.HasDefaultSchema(this.schema);
        //    base.OnModelCreating(builder);
        //}
    }
}
