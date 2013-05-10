using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ForwarderDAL.Entity;

namespace ForwarderDAL
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
        public DbSet<Load> Loadings { get; set; }
        public DbSet<Expense> Outgoes { get; set; }
        public DbSet<Road> Roads { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Shipment> Shipments { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transportation>()
                        .HasRequired(t => t.SourceStation)
                        .WithMany(s => s.TransportationsBySourceStation)
                        .HasForeignKey(t => t.SourceStationId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transportation>()
                        .HasRequired(t => t.DestinationStation)
                        .WithMany(s => s.TransportationsByDestinationStation)
                        .HasForeignKey(t => t.DestinationStationId)
                        .WillCascadeOnDelete(false);
            
            //To disable multiple cascede delete
            modelBuilder.Entity<Expense>()
                       .HasRequired(t => t.Route)
                       .WithMany(s => s.Expenses)
                       .HasForeignKey(t => t.RouteId)
                       .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                       .HasRequired(t => t.Road)
                       .WithMany(s => s.Routes)
                       .HasForeignKey(t => t.RoadId)
                       .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                       .HasRequired(t => t.Carrier)
                       .WithMany(s => s.Routes)
                       .HasForeignKey(t => t.CarrierId)
                       .WillCascadeOnDelete(false);

        }

    }
}
