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
        IQueryable<Load> Loads { get; }
        IQueryable<Expense> Expenses { get; }
        IQueryable<Road> Roads { get; }
        IQueryable<Route> Routes { get; }
        IQueryable<Shipment> Shipments { get; }
        IQueryable<ExpenseType> ExpenseTypes { get; }

        int GetTransportCount(Transportation transportation);
        bool AddNewStation(Station newStation);
        bool SaveTransportation(Transportation transportation);
        bool AddNewShipment(Shipment shipment);

        bool SaveLoad(Load load);
        bool SaveRoute(Route route);
        bool SaveExpense(Expense expense);

        bool DeleteRouteById(int routeId);

        bool DeleteLoaderById(int loaderId);
    }
}
