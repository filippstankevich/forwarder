using System.Linq;
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
        public IQueryable<Load> Loads { get { return context.Loads; } }
        public IQueryable<Expense> Expenses { get { return context.Expenses; } }
        public IQueryable<Road> Roads { get { return context.Roads; } }
        public IQueryable<Route> Routes { get { return context.Routes; } }
        public IQueryable<Shipment> Shipments { get { return context.Shipments; } }
        public IQueryable<ExpenseType> ExpenseTypes { get { return context.ExpenseTypes; } }

        public int GetTransportCount(Transportation transportation)
        {
            var result = 0;
            foreach (var loading in transportation.Loads)
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

         public bool AddNewShipment(Shipment shipment)
        {
            context.Shipments.Add(shipment);
            context.SaveChanges();
            return true;
        } 

        public IQueryable<Transportation> Transportations { get { return context.Transportations; } }

        public bool SaveLoad(Load load)
        {
            if (load.Id > 0)
            {
                Load storedLoad = context.Loads.First(o => o.Id == load.Id);
               
                storedLoad.Rate = load.Rate;
                storedLoad.Method = load.Method;
                storedLoad.Volume = load.Volume;
                storedLoad.Count = load.Count;

                context.Loads.Add(storedLoad);
            }
            else
            {
                context.Loads.Add(load);
            }           
            context.SaveChanges();

            return true;
        }


        public bool SaveRoute(Route route)
        {
            if (route.Id > 0)
            {
                Route storedRoute = context.Routes.First(o => o.Id == route.Id);

                storedRoute.RoadId = storedRoute.RoadId;
                storedRoute.CarrierId = route.CarrierId;
                storedRoute.TransportationId = route.TransportationId;

                context.Routes.Add(storedRoute);
            }
            else
            {
                context.Routes.Add(route);
            }
            context.SaveChanges();

            return true;
        }

        public bool SaveExpense(Expense expense)
        {
            if (expense.Id > 0)
            {
                Expense storedExpense = context.Expenses.First(o => o.Id == expense.Id);

                storedExpense.RouteId = expense.RouteId;
                storedExpense.Method = expense.Method;
                storedExpense.LoadId = expense.LoadId;
                storedExpense.ExpenseTypeId = expense.ExpenseTypeId;
                storedExpense.Value = expense.Value;

                context.Expenses.Add(storedExpense);
            }
            else
            {
                context.Expenses.Add(expense);
            }
            context.SaveChanges();

            return true;
        }

    }
}