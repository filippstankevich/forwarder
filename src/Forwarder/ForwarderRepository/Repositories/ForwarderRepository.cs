﻿using System.Linq;
using ForwarderDAL.Entity;

namespace ForwarderDAL.Repositories
{
    //TODO: Filipp Stankevich Зачем в названии репозитория использовать слово Forwarder
    //У нас будет еще какой-то репозиторий?
    public class ForwarderRepository : IForwarderRepository
    {
        private FRDbContext context = new FRDbContext();
        
        
        public IQueryable<Station> Stations { get { return context.Stations; } }
        public IQueryable<Gng> Gngs { get { return context.Gngs; } }
        public IQueryable<Etsng> Etsngs { get { return context.Etsngs; } }
        public IQueryable<Carrier> Carriers { get { return context.Carriers; } }
        public IQueryable<Client> Clients { get { return context.Clients; } }
        public IQueryable<Loading> Loadings { get { return context.Loadings; } }
        public IQueryable<Outgo> Outgoes { get { return context.Outgoes; } }
        public IQueryable<Road> Roads { get { return context.Roads; } }
        public IQueryable<Route> Routes { get { return context.Routes; } }

        public int GetTransportCount(Transportation transportation)
        {
            var result = 0;
            foreach (var loading in transportation.LoadingEntity)
            {
                result += loading.Count;
            }
            return result;
        }
        public bool AddNewStation(Station newStation)
        {
            context.Stations.Add(newStation);
            context.SaveChanges();
            // TODO: Сделать нормальный метод
            return true;
        }

        public bool AddNewTransportation(Transportation transportation)
        {
            context.Transportations.Add(transportation);
            context.SaveChanges();
            return true;
        }

        public IQueryable<Transportation> Transportations { get { return context.Transportations; } }
    }
}