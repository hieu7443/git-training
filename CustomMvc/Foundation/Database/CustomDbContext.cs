using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Database
{
    internal class CustomDbContext : Entities
    {
        public CustomDbContext() : base(_ConnectionString)
        {
        }
        private static string _ConnectionString { get; set; }
        public static void SetConnectionString(string connectionString)
        {
            _ConnectionString = connectionString;
        }
    }
}