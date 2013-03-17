using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForwarderDAL.Entity;

namespace ForwarderDAL.Repositories
{
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
