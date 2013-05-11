using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Forwarder.Models;
using ForwarderDAL.Entity;
using ForwarderDAL.Repositories;
using Forwarder.Helper;
using Microsoft.Office.Interop.Excel;

namespace Forwarder.Controllers
{
    public class GridController : Controller
    {
        private IForwarderRepository repository;

        private TransportationHelper helper = new TransportationHelper();

        public GridController(IForwarderRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Consumption()
        {

            var model = new ConsumptionModel
            {
                Consumption = 1,
                Loading = 2,
                Method = "123"
            };

            return PartialView("Consumption", model);
        }

        public PartialViewResult Shipping(ShippingModel model)
        {
            return PartialView("Shipping", model);
        }

        public PartialViewResult Route(RouterModel model, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Int32.Parse(id);
            }
            return PartialView("Route", model);
        }
        public PartialViewResult Consumpt(ConsumptionModel model)
        {
            return PartialView("ConsumptEdit", model);
        }

        [HttpPost]
        public PartialViewResult Loader(LoaderModel model, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                model.Id = Int32.Parse(id);
            }
            return PartialView("Loader", model);
        }

        [HttpPost]
        public ViewResult LoaderData(LoaderModel loadermodel, string id)
        {
            TransportationModel model = new TransportationModel();

            //TODO: Тормозит. Добавить кеширование для справочников или проблемы с отрисовкой?
            //TODO: Временно посмтавил выбор первых 100 значений
            IEnumerable<Gng> gngList = repository.Gngs.Take(100).ToList();
            model.GngItems = gngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Gng> etsngList = repository.Gngs.Take(100).ToList();
            model.EtsngItems = etsngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Station> stations = repository.Stations.Take(100).ToList();
            model.StationItems = stations.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });


            return View("TransportationEdit", model);
        }

        [HttpPost]
        public ViewResult RouterData(RouterModel routermodel)
        {
            TransportationModel model = new TransportationModel();

            //TODO: Тормозит. Добавить кеширование для справочников или проблемы с отрисовкой?
            //TODO: Временно посмтавил выбор первых 100 значений
            IEnumerable<Gng> gngList = repository.Gngs.Take(100).ToList();
            model.GngItems = gngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Gng> etsngList = repository.Gngs.Take(100).ToList();
            model.EtsngItems = etsngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Station> stations = repository.Stations.Take(100).ToList();
            model.StationItems = stations.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });


            return View("TransportationEdit", model);
        }


        public JsonResult LoadersView(string id)
        {
            var list = new List<object>();
            if (!string.IsNullOrEmpty(id))
            {
                int transportationId = Int32.Parse(id);
                List<Load> loads = repository.Loads.Where(o => o.TransportationId == transportationId).ToList();

                var counter = 1;
                foreach (var item in loads)
                {
                    list.Add(new
                    {
                        id = item.Id,
                        cell = new string[]
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

            var result = new JsonResult()
            {
                Data = new
                {
                    page = 1,
                    total = 1,
                    records = list.Count,
                    rows = list.ToArray()
                }
            };

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult EditView(string Loading, string Type, string Consumption, string Method)
        {

            var modelList = new List<ConsumptionModel>();
            var gridRow1 = new ConsumptionModel() { Loading = int.Parse(Loading), Type = Type, Consumption = int.Parse(Consumption), Method = Method };
            var gridRow2 = new ConsumptionModel() { Loading = int.Parse(Loading), Type = Type, Consumption = int.Parse(Consumption), Method = Method };
            var gridRow3 = new ConsumptionModel() { Loading = int.Parse(Loading), Type = Type, Consumption = int.Parse(Consumption), Method = Method };
            modelList.Add(gridRow1);
            modelList.Add(gridRow2);
            modelList.Add(gridRow3);

            var list = new List<object>();
            var counter = 0;

            foreach (var item in modelList)
            {
                list.Add(new
                {
                    id = ++counter,
                    cell = new string[]
                            {
                                counter.ToString(),
                                item.Loading!= null ? item.Loading.Value.ToString() : string.Empty,
                                !string.IsNullOrEmpty(item.Type) ? item.Type.ToString() : string.Empty,
                                item.Consumption!= null ? item.Consumption.Value.ToString() : string.Empty,
                                !string.IsNullOrEmpty(item.Method) ? item.Method.ToString() : string.Empty,
                               
                            }
                });
            }

            var result = new JsonResult()
            {
                Data = new
                {
                    page = 1,
                    total = 1,
                    records = list.Count,
                    rows = list.ToArray()
                }
            };

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
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
            
            var result = new JsonResult()
            {
                Data = new
                {
                    page = 1,
                    total = 1,
                    records = list.Count,
                    rows = list.ToArray()
                }
            };

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
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
                    cell = new string[]
                            {
                                counter.ToString(),
                                item.ExpenseType != null ? item.ExpenseType.Name : string.Empty,
                                item.Value.ToString()                               
                            }
                });
                counter++;
            }

            var result = new JsonResult()
            {
                Data = new
                {
                    page = 1,
                    total = 1,
                    records = list.Count,
                    rows = list.ToArray()
                }
            };

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
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
                        cell = new string[]
                            {
                                counter.ToString(),
                                item.Road != null ? item.Road.ShortName : string.Empty,
                                item.Carrier != null ? item.Carrier.ShortName: string.Empty,
                                item.Expenses.Sum(o=>o.Value).ToString()
                            }
                    });
                }
            }

            var result = new JsonResult()
            {
                Data = new
                {
                    page = 1,
                    total = 1,
                    records = list.Count,
                    rows = list.ToArray()
                }
            };

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }

        public JsonResult GridView(string RegNumber, string DispatchStation, string ArriveStattion,
                                   string GHGClassificator, string ETSNGClassificator, DateTime? RegDate)
        {
            var transportations = repository.Transportations.ToList();

            if (!string.IsNullOrEmpty(RegNumber))
                transportations = transportations.Where(d => d.RegNumber.Contains(RegNumber)).ToList();
            if (!string.IsNullOrEmpty(DispatchStation))
                transportations = transportations.Where(d => d.DestinationStation.Name.Contains(DispatchStation)).ToList();
            if (!string.IsNullOrEmpty(ArriveStattion))
                transportations = transportations.Where(d => d.SourceStation.Name.Contains(ArriveStattion)).ToList();
            if (!string.IsNullOrEmpty(GHGClassificator))
                transportations = transportations.Where(d => d.Gng.Code.Contains(GHGClassificator)).ToList();
            if (!string.IsNullOrEmpty(ETSNGClassificator))
                transportations = transportations.Where(d => d.Etsng.Code.Contains(ETSNGClassificator)).ToList();
            if (RegDate != null)
                transportations = transportations.Where(d => d.CreateDate == RegDate.Value).ToList();

            var list = new List<object>();
            var counter = 1;

            foreach (var item in transportations)
            {
                list.Add(new
                    {
                        id = item.Id,
                        cell = new string[]
                            {
                                counter.ToString(),
                                !string.IsNullOrEmpty(item.RegNumber) ? item.RegNumber : string.Empty,
                                item.DestinationStation != null ? item.DestinationStation.Name : string.Empty,
                                item.SourceStation != null ? item.SourceStation.Name : string.Empty,
                                item.Gng != null ? item.Gng.Code : string.Empty,
                                item.Etsng != null ? item.Etsng.Code : string.Empty,
                                item.CreateDate.ToString(),
                                item.Loads != null ? repository.GetTransportCount(item).ToString() : string.Empty,
                            }
                    });
                counter++;
            }

            var result = new JsonResult()
                {
                    Data = new
                        {
                            page = 1,
                            total = 1,
                            records = list.Count,
                            rows = list.ToArray()
                        }
                };

            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return result;
        }


        public ViewResult TransportationEdit(string Id, string RegNumber, string GHGClassificator, string ETSNGClassificator,
                                              string DispatchStation, string ArriveStattion, string Comment)
        {
            TransportationModel model = new TransportationModel();

            //Подтягивание данных по выбранной перевозке
            if (Id != null && Id.Length > 0)
            {
                int id = Int32.Parse(Id);
                Transportation transportation = repository.Transportations.Where(o => o.Id == id).Single();
                model.RegNumber = transportation.RegNumber;
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
            }


            //Инициализация справочников

            //TODO: Тормозит. Добавить кеширование для справочников или проблемы с отрисовкой?
            //TODO: Временно посмтавил выбор первых 100 значений
            IEnumerable<Gng> gngList = repository.Gngs.Take(100).ToList();
            model.GngItems = gngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Gng> etsngList = repository.Gngs.Take(100).ToList();
            model.EtsngItems = etsngList.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            IEnumerable<Station> stations = repository.Stations.Take(100).ToList();
            model.StationItems = stations.Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name });

            return View(model);
        }

        [HttpPost]
        public ActionResult TransportationEdit(TransportationModel model)
        {
            int sourceStationId = Int32.Parse(model.SourceStationId);
            int destinationStationId = Int32.Parse(model.SourceStationId);
            int gngId = Int32.Parse(model.GngId);
            int etsngId = Int32.Parse(model.EtsngId);

            Transportation transportation = new Transportation()
                {
                    Id = !string.IsNullOrEmpty(model.Id) ? Int32.Parse(model.Id) : -1,
                    CreateDate = DateTime.Now,
                    RegNumber = model.RegNumber,
                    SourceStation = repository.Stations.Where(s => s.Id == sourceStationId).SingleOrDefault(),
                    DestinationStation =
                        repository.Stations.Where(s => s.Id == destinationStationId).SingleOrDefault(),
                    Gng = repository.Gngs.Where(s => s.Id == gngId).SingleOrDefault(),
                    Etsng = repository.Etsngs.Where(s => s.Id == etsngId).SingleOrDefault()
                };
            repository.AddNewTransportation(transportation);

            return View("Index");
        }

        [HttpPost]
        public void ExportData(string id)
        {
            int transportationId = Int32.Parse(id);

            ExcelImporter importer = new ExcelImporter();
            List<Shipment> shipments = importer.Import("D:/loadd2007.xls");

            foreach (Shipment shipment in shipments)
            {
                shipment.TransportationId = transportationId;
                repository.AddNewShipment(shipment);
            }
       }
    }
}
