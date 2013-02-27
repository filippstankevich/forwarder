using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ForwarderDAL.Entity
{
    public class FRDbContext : DbContext
    {
        public DbSet<SomeObject> Objects { get; set; }
    }
}
