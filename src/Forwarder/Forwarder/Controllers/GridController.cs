using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Forwarder.Models;
using ForwarderDAL.Entity;
using ForwarderDAL.Repositories;

namespace Forwarder.Controllers
{
    public class GridController : Controller
    {
        private IForwarderRepository repository;

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

        public PartialViewResult Route(RouterModel model)
        {
            return PartialView("Route", model);
        }
        public PartialViewResult Consumpt(ConsumptionModel model)
        {
            return PartialView("ConsumptEdit", model);
        }

        [HttpPost]
        public PartialViewResult Loader(LoaderModel model)
        {           
            return PartialView("Loader",model);
        }

        [HttpPost]
        public ViewResult LoaderData(LoaderModel loadermodel)
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


            return View("TransportationEdit",model);
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


        public JsonResult LoadersView()
        {

            var listresult1 = new List<LoaderModel>();
            var gridRow1 = new LoaderModel() { Loading = 1, Rate = 2, Сonsumption = 3 };
            var gridRow2 = new LoaderModel() { Loading = 2, Rate = 4, Сonsumption = 4 };
            var gridRow3 = new LoaderModel() { Loading = 4, Rate = 3, Сonsumption = 3 };
            listresult1.Add(gridRow1);
            listresult1.Add(gridRow2);
            listresult1.Add(gridRow3);

            var list = new List<object>();
            var counter = 0;

            foreach (var item in listresult1)
            {
                list.Add(new
                {
                    id = ++counter,
                    cell = new string[]
                            {
                                counter.ToString(),         
                                item.Loading != null ? item.Loading.Value.ToString() : string.Empty,
                                !string.IsNullOrEmpty(item.Method) ? item.Method.ToString() : string.Empty,
                                item.Rate!= null ? item.Rate.Value.ToString() : string.Empty,
                                item.Сonsumption!= null ? item.Сonsumption.Value.ToString() : string.Empty,
                                item.Count != null ? item.Count.Value.ToString() : string.Empty,
                                                              
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

        public JsonResult EditView(string Loading, string Type, string Consumption, string Method)
        {

 
            var listresult1 = new List<ConsumptionModel>();
            var gridRow1 = new ConsumptionModel() { Loading = int.Parse(Loading), Type = Type, Consumption = int.Parse(Consumption), Method = Method };
            var gridRow2 = new ConsumptionModel() { Loading = int.Parse(Loading), Type = Type, Consumption = int.Parse(Consumption), Method = Method };
            var gridRow3 = new ConsumptionModel() { Loading = int.Parse(Loading), Type = Type, Consumption = int.Parse(Consumption), Method = Method };
            listresult1.Add(gridRow1);
            listresult1.Add(gridRow2);
            listresult1.Add(gridRow3);
            
            var list = new List<object>();
            var counter = 0;

            foreach (var item in listresult1)
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

       
        public JsonResult ConsumptionView()
        {

            
            var listresult1 = new List<ConsumptionModel>();
            var gridRow1 = new ConsumptionModel() { Loading = 123, Type = "sss", Consumption = 545,Method = "asa" };
            var gridRow2 = new ConsumptionModel() { Loading = 124, Type = "sas", Consumption = 4554, Method = "sas" };
            var gridRow3 = new ConsumptionModel() { Loading = 125, Type = "sasa", Consumption = 5454, Method = "wqw" };
            listresult1.Add(gridRow1);
            listresult1.Add(gridRow2);
            listresult1.Add(gridRow3);

            var list = new List<object>();
            var counter = 0;

            foreach (var item in listresult1)
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

        public JsonResult RouteView()
        {


            var listresult1 = new List<RouterModel>();
            var gridRow1 = new RouterModel() { Road = "123", Carrier = "sss", Сonsumption = 1 };
            var gridRow2 = new RouterModel() { Road = "143", Carrier = "aaa", Сonsumption = 2 };
            var gridRow3 = new RouterModel() { Road = "133", Carrier = "ccc", Сonsumption = 3 };
            listresult1.Add(gridRow1);
            listresult1.Add(gridRow2);
            listresult1.Add(gridRow3);

            var list = new List<object>();
            var counter = 0;

            foreach (var item in listresult1)
            {
                list.Add(new
                {
                    id = ++counter,
                    cell = new string[]
                            {
                                counter.ToString(),
                                !string.IsNullOrEmpty(item.Road) ? item.Road.ToString() : string.Empty,
                                !string.IsNullOrEmpty(item.Carrier) ? item.Carrier.ToString() : string.Empty,
                                item.Сonsumption!= null ? item.Сonsumption.Value.ToString() : string.Empty,
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

        public JsonResult GridView(string RegNumber, string DispatchStation, string ArriveStattion,
                                   string GHGClassificator, string ETSNGClassificator, DateTime? RegDate)
        {
            var listresult1 = repository.Transportations.ToList();

            if (!string.IsNullOrEmpty(RegNumber))
                listresult1 = listresult1.Where(d => d.RegNumber.Contains(RegNumber)).ToList();
            if (!string.IsNullOrEmpty(DispatchStation))
                listresult1 = listresult1.Where(d => d.DestinationStation.Name.Contains(DispatchStation)).ToList();
            if (!string.IsNullOrEmpty(ArriveStattion))
                listresult1 = listresult1.Where(d => d.SourceStation.Name.Contains(ArriveStattion)).ToList();
            if (!string.IsNullOrEmpty(GHGClassificator))
                listresult1 = listresult1.Where(d => d.Gng.Code.Contains(GHGClassificator)).ToList();
            if (!string.IsNullOrEmpty(ETSNGClassificator))
                listresult1 = listresult1.Where(d => d.Etsng.Code.Contains(ETSNGClassificator)).ToList();
            if (RegDate != null)
                listresult1 = listresult1.Where(d => d.CreateDate == RegDate.Value).ToList();

            var list = new List<object>();
            var counter = 0;

            foreach (var item in listresult1)
            {
                list.Add(new
                    {
                        id = ++counter,
                        cell = new string[]
                            {
                                counter.ToString(),
                                !string.IsNullOrEmpty(item.RegNumber) ? item.RegNumber : string.Empty,
                                item.DestinationStation != null ? item.DestinationStation.Name : string.Empty,
                                item.SourceStation != null ? item.SourceStation.Name : string.Empty,
                                item.Gng != null ? item.Gng.Code : string.Empty,
                                item.Etsng != null ? item.Etsng.Code : string.Empty,
                                item.CreateDate != null ? item.CreateDate.ToString() : string.Empty,
                                // TODO: Сделать подсчет транспорта и коментарий
                                item.LoadingEntity != null ? repository.GetTransportCount(item).ToString() : string.Empty,
                                // !string.IsNullOrEmpty(item.Comments) ? item.Comments.ToString() : string.Empty
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


        public ViewResult TransportationEdit(string RegNumber, string GHGClassificator, string ETSNGClassificator,
                                              string DispatchStation, string ArriveStattion, string Comment  )
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
            

            return View(model);
        }

       

        [HttpPost]
        public ActionResult TransportationEdit(TransportationModel model)
        {

                int sourceStationId = Int32.Parse(model.SourceStation);
                int destinationStationId = Int32.Parse(model.SourceStation);
                int gngId = Int32.Parse(model.Gng);
                int etsngId = Int32.Parse(model.Etsng);


                Transportation transportation = new Transportation()
                    {
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
    }
}
