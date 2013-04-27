using System.Linq;
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
        IQueryable<Gng> Gngs { get; }
        IQueryable<Etsng> Etsngs { get; }
        IQueryable<Carrier> Carriers { get; }
        IQueryable<Client> Clients { get; }
        IQueryable<Loading> Loadings { get; }
        IQueryable<Outgo> Outgoes { get; }
        IQueryable<Road> Roads { get; }
        IQueryable<Route> Routes { get; }

        int GetTransportCount(Transportation transportation);
        bool AddNewStation(Station newStation);
        bool AddNewTransportation(Transportation transportation);
    }
}
