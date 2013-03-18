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
        // IQueryable<SomeObject> SomeObjects { get; }
        IQueryable<Station> Stations { get; }
        IQueryable<Transportation> Transportations { get; }
        IQueryable<GNG> Gngs { get; }
        IQueryable<ETSNG> Etsngs { get; }

        bool AddNewStation(Station NewStation);
    }
}
