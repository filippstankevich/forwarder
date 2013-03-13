using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForwarderDAL.Entity;

namespace ForwarderDAL.Repositories
{
    //TODO: Filipp Stankevich Зачем в названии репозитория использовать слово Forwarder
    //У нас будет еще какой-то репозиторий?
    public class ForwarderRepository : IForwarderRepository
    {
        private FRDbContext context = new FRDbContext();

        public IQueryable<SomeObject> SomeObjects { get { return context.Objects; } }
        public IQueryable<StationEntity> Stations { get { return context.Stations; } }
        public IQueryable<GNG_Entity> Gngs { get { return context.Gngs; } }
        public IQueryable<ETSNG_Entity> Etsngs { get { return context.Etsngs; } }
        public IQueryable<TransportationEntity> Transportations { get { return context.Transportations; } }
    }
}