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
        public FRDbContext() : base("defaultConnectionString") { }
        public DbSet<SomeObject> Objects { get; set; }
        public DbSet<ETSNG_Entity> Etsngs { get; set; }
        public DbSet<GNG_Entity> Gngs { get; set; }
        public DbSet<StationEntity> Stations { get; set; }
        public DbSet<TransportationEntity> Transportations { get; set; }

    }
}
