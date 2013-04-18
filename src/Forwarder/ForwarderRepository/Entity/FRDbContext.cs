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
        public DbSet<Etsng> Etsngs { get; set; }
        public DbSet<Gng> Gngs { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Transportation> Transportations { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loading> Loadings { get; set; }
        public DbSet<Outgo> Outgoes { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<Route> Routes { get; set; }

    }
}
