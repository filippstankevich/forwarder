using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForwarderDAL.Entity;

namespace ForwarderDAL.Repositories
{
    //TODO: Filipp Stankevich Зачем в названии репозитория использовать слово Forwarder
    //У нас будет еще какой-то репозиторий?
    public interface IForwarderRepository
    {
        IQueryable<SomeObject> SomeObjects { get; }
        IQueryable<StationEntity> Stations { get; }
        IQueryable<TransportationEntity> Transportations { get; }
        IQueryable<GNG_Entity> Gngs { get; }
        IQueryable<ETSNG_Entity> Etsngs { get; }
    }
}
