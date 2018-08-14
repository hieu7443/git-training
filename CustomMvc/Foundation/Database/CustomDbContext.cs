using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Database
{
    internal class CustomDbContext : Entities
    {
        internal CustomDbContext() : base()
        {
            Database.Connection.ConnectionString = _ConnectionString;
        }
        private static string _ConnectionString { get; set; }
        internal static void SetConnectionString(string connectionString)
        {
            _ConnectionString = connectionString;
        }
    }
}