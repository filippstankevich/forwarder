using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using ForwarderDAL.Entity;
using Npgsql;

namespace ForwarderDAL.Repositories
{
    public class ForwarderRepository : IForwarderRepository
    {
        private FRDbContext context = new FRDbContext();
        
        // IQueryable<SomeObject> SomeObjects { get { return context.Objects; } }
        public IQueryable<Station> Stations { get { return context.Stations; } }
        public IQueryable<GNG> Gngs { get { return context.Gngs; } }
        public IQueryable<ETSNG> Etsngs { get { return context.Etsngs; } }
        public bool AddNewStation(Station NewStation)
        {
            var station = Stations.FirstOrDefault();
            station = new Station();
            station.Code = "1";
            station.Name = "1";
            context.Stations.Add(station);
            context.SaveChanges();
            // TODO: Сделать нормальный метод
            return true;
        }

        public IQueryable<Transportation> Transportations { get { return context.Transportations; } }
    }
}