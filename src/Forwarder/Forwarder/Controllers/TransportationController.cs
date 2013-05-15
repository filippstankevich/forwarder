using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Forwarder.Models;
using ForwarderDAL.Entity;
using ForwarderDAL.Repositories;
using Forwarder.Helper;
using System.Web;


namespace Forwarder.Controllers
{
    public class TransportationController : Controller
    {
        private readonly IForwarderRepository repository;

        private readonly TransportationHelper helper = new TransportationHelper();

        public TransportationController(IForwarderRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Consumption(ExpenseModel model)
        {
            return PartialView("Consumption", model);
        }

        public PartialViewResult Consumpt(ExpenseModel model)
        {
            IEnumerable<ExpenseType> expenseTypes = repository.ExpenseTypes.ToList();
            model.ExpenseTypes = expenseTypes.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Load> loads = repository.Loads.Where(o => o.TransportationId == model.Id);
            model.Loads = loads.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Volume.ToString() });

            model.Methods = new [] {
                new SelectListItem() { Value = "false", Text = "За вагон" },
                new SelectListItem() { Value = "true", Text = "За тонну" }
            };

             if (model.ExpenseId > 0)
             {
                 Expense expense = repository.Expenses.Where(o => o.Id == model.ExpenseId).Single();
                 model.LoadId = expense.LoadId;
             }

            return PartialView("ConsumptEdit", model);
        }

        public PartialViewResult Shipping(ShipmentModel model)
        {
            return PartialView("Shipping", model);
        }

        public PartialViewResult Route(RouteModel model, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Int32.Parse(id);
            }

            if (model.RouteId != null)
            {
                Route route = repository.Routes.Where(o => o.Id == model.RouteId.Value).Single();
                model.RoadId = route.RoadId.ToString();
                model.CarrierId = route.CarrierId.ToString();
            }

            IEnumerable<Carrier> carriers = repository.Carriers.ToList();
            model.Carriers = carriers.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Road> roads = repository.Roads.ToList();
            model.Roads = roads.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            return PartialView("Route", model);
        }

        public PartialViewResult Loader(LoadModel model, string LoadId, string id)
        {
         
            model.Id = Int32.Parse(id);

            if (!string.IsNullOrEmpty(LoadId))
            {
                model.LoadId = Int32.Parse(LoadId);
            }

            model.Methods = new [] {
                new SelectListItem() { Value = "false", Text = "За вагон" },
                new SelectListItem() { Value = "true", Text = "За тонну" }
            };

            return PartialView("Loader", model);
        }

        [HttpPost]
        public ViewResult LoaderData(LoadModel model)
        { 
            Load load = new Load()
            {
                Id = model.LoadId,
                TransportationId = model.Id,
                Count = model.Count,
                Method = model.Method,
                Volume = model.Volume,
                Rate = model.Rate                
            };

            repository.SaveLoad(load);

            TransportationModel transportationModel  =  CreateTransporatationModel();
            FillTransportationModel(transportationModel, model.Id);
            return View("TransportationEdit", transportationModel);
        }

        [HttpPost]
        public ViewResult RouterData(RouteModel model)
        {
            Route route = new Route()
            {
                Id = model.RouteId != null ? model.RouteId.Value : 0,
                TransportationId = model.Id !=null ? model.Id.Value : 0,
                RoadId = model.RoadId != null ? Int32.Parse(model.RoadId) : 0,
                CarrierId = model.CarrierId != null ? Int32.Parse(model.CarrierId) : 0
            };

            repository.SaveRoute(route);

            TransportationModel transportationModel = CreateTransporatationModel();
            FillTransportationModel(transportationModel, model.Id.Value);

            return View("TransportationEdit", transportationModel);
        }

        [HttpPost]
        public ViewResult ExpenseData(ExpenseModel model)
        {

            Expense expense = new Expense
            {
                Id  =  model.ExpenseId,
                RouteId = model.RouteId,
                LoadId = model.LoadId,
                ExpenseTypeId = Int32.Parse(model.ExpenseTypeId),
                Method  = model.Method,
                Value = model.Expense != null ? model.Expense.Value : 0
            };

            repository.SaveExpense(expense);

            TransportationModel transportationModel = CreateTransporatationModel();
            FillTransportationModel(transportationModel, model.Id);
            //transportationModel.OpenDialogEx = true;
            //transportationModel.RoutId = model.RouteId;
            //RedirectToAction("TransportationEdit", transportationModel);
            return View("TransportationEdit", transportationModel);
        }


        public JsonResult LoadersView(string id, string transportationId)
        {
            var list = new List<object>();
            if (!string.IsNullOrEmpty(id))
            {
                int transpId = Int32.Parse(id);
                List<Load> loads = repository.Loads.Where(o => o.TransportationId == transpId).ToList();

                var counter = 1;
                foreach (var item in loads)
                {
                    list.Add(new
                    {
                        id = item.Id,
                        cell = new []
                            {
                                counter.ToString(),                     
                                item.Volume.ToString(),
                                item.Rate.ToString(),
                                item.Expenses != null ? item.Expenses.Sum(o=>o.Value).ToString() : "0",
                                item.Method.ToString(),
                                item.Count.ToString()    
                            }
                    });
                    counter++;
                }
            }

            return ToJsonResult(list);
        }

        public JsonResult ShippingView(string id)
        {
            int transportationId = Int32.Parse(id);
            List<Shipment> shipments = repository.Shipments.Where(o => o.TransportationId == transportationId).ToList();

            var counter = 1;
            var list = new List<object>();
            foreach (var item in shipments)
            {
                list.Add(new
                {
                    id = item.Id,
                    cell = new string[]
                            {
                                counter.ToString(),                     
                                item.WagonNumber,
                                item.BillNumber,
                                item.Weight.ToString(),
                                item.Capacity.ToString(),
                                item.Date.ToShortDateString(),
                                item.ArrivalDate != null ? item.ArrivalDate.Value.ToShortDateString() : string.Empty
                            }
                });
                counter++;
            }

            return ToJsonResult(list);
        }

        public JsonResult ConsumptionView(string id)
        {
            int routeId = Int32.Parse(id);
            List<Expense> expenses = repository.Expenses.Where(o => o.RouteId == routeId).ToList();

            var list = new List<object>();
            var counter = 1;
            foreach (var item in expenses)
            {
                list.Add(new
                {
                    id = item.Id,
                    cell = new []
                            {
                                counter.ToString(),
                                item.ExpenseType != null ? item.ExpenseType.Name : string.Empty,
                                item.Load != null ? item.Load.Volume.ToString() : string.Empty,
                                item.Value.ToString(),
                                item.Method.ToString()
                            }
                });
                counter++;
            }

            return ToJsonResult(list);
        }

        public JsonResult RouteView(string id)
        {
            var list = new List<object>();
            if (!string.IsNullOrEmpty(id))
            {
                int transportationId = Int32.Parse(id);
                List<Route> routes = repository.Routes.Where(o => o.TransportationId == transportationId).ToList();

                var counter = 1;
                foreach (var item in routes)
                {
                    list.Add(new
                    {
                        id = item.Id,
                        cell = new []
                            {
                                counter.ToString(),
                                item.Road != null ? item.Road.ShortName : string.Empty,
                                item.Carrier != null ? item.Carrier.ShortName: string.Empty,
                                item.Expenses.Sum(o=>o.Value).ToString()
                            }
                    });
                    counter++;
                }
            }

            return ToJsonResult(list);
        }

        public JsonResult GridView(string regNumber, string dispatchStation, string arriveStattion,
                                   string ghgClassificator, string etsngClassificator, DateTime? regDate)
        {
            var transportations = repository.Transportations.ToList();

            if (!string.IsNullOrEmpty(regNumber))
                transportations = transportations.Where(d => d.RegNumber.Contains(regNumber)).ToList();
            if (!string.IsNullOrEmpty(dispatchStation))
                transportations = transportations.Where(d => d.DestinationStation.Name.Contains(dispatchStation)).ToList();
            if (!string.IsNullOrEmpty(arriveStattion))
                transportations = transportations.Where(d => d.SourceStation.Name.Contains(arriveStattion)).ToList();
            if (!string.IsNullOrEmpty(ghgClassificator))
                transportations = transportations.Where(d => d.Gng.Code.Contains(ghgClassificator)).ToList();
            if (!string.IsNullOrEmpty(etsngClassificator))
                transportations = transportations.Where(d => d.Etsng.Code.Contains(etsngClassificator)).ToList();
            if (regDate != null)
                transportations = transportations.Where(d => d.CreateDate == regDate.Value).ToList();

            var list = new List<object>();
            var counter = 1;
            foreach (var item in transportations)
            {
                list.Add(new
                    {
                        id = item.Id,
                        cell = new []
                            {
                                counter.ToString(),
                                !string.IsNullOrEmpty(item.RegNumber) ? item.RegNumber : string.Empty,
                                item.DestinationStation != null ? item.DestinationStation.Name : string.Empty,
                                item.SourceStation != null ? item.SourceStation.Name : string.Empty,
                                item.Gng != null ? item.Gng.Code : string.Empty,
                                item.Etsng != null ? item.Etsng.Code : string.Empty,                                
                                item.Loads != null ? repository.GetTransportCount(item).ToString() : string.Empty,
                                item.CreateDate.ToString(),
                                item.Comment
                            }
                    });
                counter++;
            }

            return ToJsonResult(list);
        }


        public ViewResult TransportationEdit(string id, string regNumber, string ghgClassificator, string etsngClassificator,
                                              string dispatchStation, string arriveStattion, string comment)
        {
            TransportationModel model = CreateTransporatationModel();

            //Подтягивание данных по выбранной перевозке
            if (!string.IsNullOrEmpty(id))
            {
                int transportationId = Int32.Parse(id);
                FillTransportationModel(model, transportationId);
            }
            else
            {
                Transportation transportation = new Transportation();
                transportation.CreateDate = DateTime.Now;
                repository.SaveTransportation(transportation);
                model.Id = transportation.Id.ToString();
            }

            return View(model);
        }

        private TransportationModel CreateTransporatationModel()
        {
            TransportationModel model = new TransportationModel();

            //Инициализация справочников

            //TODO: Тормозит. Добавить кеширование для справочников или проблемы с отрисовкой?
            //TODO: Временно посмтавил выбор первых 100 значений
            IEnumerable<Gng> gngList = repository.Gngs.Take(100).ToList();
            model.GngItems = gngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Etsng> etsngList = repository.Etsngs.Take(100).ToList();
            model.EtsngItems = etsngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Station> stations = repository.Stations.Take(100).ToList();
            model.StationItems = stations.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            return model;
        }

        private void FillTransportationModel(TransportationModel model,  int id)
        {
            if (id > 0)
            {
                Transportation transportation = repository.Transportations.Where(o => o.Id == id).Single();

                model.Id = transportation.Id.ToString();

                model.RegNumber = transportation.RegNumber;
                model.Comment = transportation.Comment;
                model.EtsngId = transportation.Etsng != null ?
                    transportation.Etsng.Id.ToString() : string.Empty;
                model.GngId = transportation.Gng != null ?
                    transportation.Gng.Id.ToString() : string.Empty;
                model.SourceStationId = transportation.SourceStation != null ?
                    transportation.SourceStation.Id.ToString() : string.Empty;
                model.DestinationStationId = transportation.DestinationStation != null ?
                    transportation.DestinationStation.Id.ToString() : string.Empty;

                model.PlannedExpense = helper.GetPlannedExpense(transportation);
                model.PlannedPrice = helper.GetPlannedPrice(transportation);
                model.PlannedProfit = model.PlannedPrice - model.PlannedExpense;

                model.RealExpense = helper.GetRealExpense(transportation);
                model.RealPrice = helper.GetRealPrice(transportation);
                model.RealProfit = model.RealPrice - model.RealExpense;
            }
        }

        [HttpPost]
        public ActionResult TransportationEdit(TransportationModel model)
        {
            int sourceStationId = Int32.Parse(model.SourceStationId);
            int destinationStationId = Int32.Parse(model.DestinationStationId);
            int gngId = Int32.Parse(model.GngId);
            int etsngId = Int32.Parse(model.EtsngId);

            Transportation transportation = new Transportation()
                {
                    Id =  !string.IsNullOrEmpty(model.Id) ? Int32.Parse(model.Id) : 0,
                    CreateDate = DateTime.Now,
                    RegNumber = model.RegNumber,
                    SourceStationId = sourceStationId,
                    DestinationStationId = destinationStationId,
                    GngId = gngId,
                    EtsngId = etsngId,
                    Comment = model.Comment
                };
            repository.SaveTransportation(transportation);

            return View("Index");
        }

        [HttpPost]
        public PartialViewResult ExportData(HttpPostedFileBase file, string id)
        {
            int transportationId = Int32.Parse(id);

            //Filipp Stankevich TODO: Workaroud to send file name into ExcelImporter
            string tempFileName = "C:/Windows/Temp/" + DateTime.Now.Millisecond.ToString() + ".xls";

            file.SaveAs(tempFileName);

            ExcelImporter importer = new ExcelImporter();
            List<Shipment> shipments;
            try
            {             
                shipments = importer.Import(tempFileName);               
            }
            finally
            {
                TryToDeleteFile(tempFileName);               
            }

            if (shipments != null)
            {
                foreach (Shipment shipment in shipments)
                {
                    shipment.TransportationId = transportationId;
                    repository.AddNewShipment(shipment);
                }
            }

            return PartialView("Shipping", new ShipmentModel() { Id = transportationId.ToString() }); 
       }

        private void TryToDeleteFile(string fileName)
        {
            try
            {
                System.IO.File.Delete(fileName);
            }
            catch
            {
                //Nothing to do
            }
        }

        private JsonResult ToJsonResult(List<object> list)
        {
            return new JsonResult()
            {
                Data = new
                {
                    page = 1,
                    total = 1,
                    records = list.Count,
                    rows = list.ToArray()
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}
