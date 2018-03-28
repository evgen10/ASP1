using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task_1.Models
{
    /// <summary>
    /// Provides an access to database
    /// </summary>
    public class Context: DbContext
    {
       
        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
    }
}