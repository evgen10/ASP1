﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Task_1.Models
{
    public class Context: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Award> Awards { get; set; }
    }
}