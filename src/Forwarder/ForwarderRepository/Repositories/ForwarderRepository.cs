using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using ForwarderDAL.Entity;
using Npgsql;

namespace ForwarderDAL.Repositories
{
    //TODO: Filipp Stankevich Зачем в названии репозитория использовать слово Forwarder
    //У нас будет еще какой-то репозиторий?
    public class ForwarderRepository : IForwarderRepository
    {
        private FRDbContext context = new FRDbContext();
        
        // IQueryable<SomeObject> SomeObjects { get { return context.Objects; } }
        public IQueryable<Station> Stations { get { return context.Stations; } }
        public IQueryable<GNG> Gngs { get { return context.Gngs; } }
        public IQueryable<ETSNG> Etsngs { get { return context.Etsngs; } }
        public bool AddNewStation(Station NewStation)
        {
            context.Stations.Add(NewStation);
            context.SaveChanges();
            return true;
        }

        public IQueryable<Transportation> Transportations { get { return context.Transportations; } }
    }
}