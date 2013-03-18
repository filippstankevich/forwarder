using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ForwarderDAL.Entity
{
    //TODO: Filipp Stankevich Убрать префикc FR  
    public class FRDbContext : DbContext
    {
        public DbSet<ETSNG> Etsngs { get; set; }
        public DbSet<GNG> Gngs { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Transportation> Transportations { get; set; }

    }
}
