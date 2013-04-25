using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Forwarder.Models;
using ForwarderDAL.Entity;

namespace Forwarder.Controllers
{
    public class GridController : Controller
    {
        //
        // GET: /Grid/

        public ActionResult Index()
        {
            return View(new List<Station>() { new Station() { Code = "1", ID = 1, Name = "name" } });
        }

        public ActionResult NewView()
        {
            return PartialView(new List<Station>() {new Station() {Code = "1", ID = 1, Name = "name"}});
        }
        
        public PartialViewResult PartView()
        {
            var model = new StationModel
                {
                    Station = new Station {Code = "QWERTYUIOP", ID = 1, Name = "ASDFGHJKL"},
                    Result = "ЧТОТО"
                };
            return PartialView("PartView", model);
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

        [HttpPost]
        public PartialViewResult Loader(string Loading, string Rate, string Сonsumption, string Method, string Count)
        {
            var model = new LoaderModel
            {
                Loading = !string.IsNullOrEmpty(Loading) ?int.Parse(Loading) : 0,
                Rate = !string.IsNullOrEmpty(Rate) ? int.Parse(Rate) : 0,
                Сonsumption = !string.IsNullOrEmpty(Сonsumption) ? int.Parse(Сonsumption) : 0,
                Method = !string.IsNullOrEmpty(Method) ? Method : string.Empty,
                Count = !string.IsNullOrEmpty(Count) ? int.Parse(Count) : 0
                
                
                
            };

            return PartialView("Loader",model);
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
                                   string GHGClassificator, string ETSNGClassificator, string RegDate)
        {
            var listresult1 = new List<GridModel>();
            var gridRow1 = new GridModel() {RegNumber = "123", DispatchStation = "2", ArriveStattion = "1"};
            var gridRow2 = new GridModel() {RegNumber = "124", DispatchStation = "3", ArriveStattion = "2"};
            var gridRow3 = new GridModel() {RegNumber = "125", DispatchStation = "4", ArriveStattion = "5"};
            listresult1.Add(gridRow1);
            listresult1.Add(gridRow2);
            listresult1.Add(gridRow3);
            
            if (!string.IsNullOrEmpty(RegNumber))
                listresult1 = listresult1.Where(d => d.RegNumber.Contains(RegNumber)).ToList();
            if (!string.IsNullOrEmpty(DispatchStation))
                listresult1 = listresult1.Where(d => d.DispatchStation.Contains(DispatchStation)).ToList();
            if (!string.IsNullOrEmpty(ArriveStattion))
                listresult1 = listresult1.Where(d => d.ArriveStattion.Contains(ArriveStattion)).ToList();
            if (!string.IsNullOrEmpty(GHGClassificator))
                listresult1 = listresult1.Where(d => d.GHGClassificator.Contains(GHGClassificator)).ToList();
            if (!string.IsNullOrEmpty(ETSNGClassificator))
                listresult1 = listresult1.Where(d => d.ETSNGClassificator.Contains(ETSNGClassificator)).ToList();
            if (!string.IsNullOrEmpty(RegDate))
                listresult1 = listresult1.Where(d => d.RegDate == RegDate).ToList();

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
                                !string.IsNullOrEmpty(item.RegNumber) ? item.RegNumber.ToString() : string.Empty,
                                !string.IsNullOrEmpty(item.DispatchStation)
                                    ? item.DispatchStation.ToString()
                                    : string.Empty,
                                !string.IsNullOrEmpty(item.ArriveStattion)
                                    ? item.ArriveStattion.ToString()
                                    : string.Empty,
                                !string.IsNullOrEmpty(item.GHGClassificator)
                                    ? item.GHGClassificator.ToString()
                                    : string.Empty,
                                !string.IsNullOrEmpty(item.ETSNGClassificator)
                                    ? item.ETSNGClassificator.ToString()
                                    : string.Empty,
                                !string.IsNullOrEmpty(item.RegDate) ? item.RegDate.ToString() : string.Empty,
                                item.TransportCount != null ? item.TransportCount.Value.ToString() : string.Empty,
                                !string.IsNullOrEmpty(item.Comments) ? item.Comments.ToString() : string.Empty
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

        //public class GridModel
        //{
        //    public int Id { get; set; }
        //    public string RegNumber { get; set; }
        //    public string DispatchStation { get; set; }
        //    public string ArriveStattion { get; set; }
        //    public string GHGClassificator { get; set; }
        //    public string ETSNGClassificator { get; set; }
        //    public int? TransportCount { get; set; }
        //    public string FullWeight { get; set; }
        //    public string Comments { get; set; }
        //    public string RegDate { get; set; }
        //}

        //public class LoaderModel
        //{
        //   public int? Id {get;set;}
        //   public int? Loading {get;set;}
        //   public int? Rate { get; set;}
        //   public int? Сonsumption {get;set;}
        //   public string Method {get;set;}
        //   public int? Count { get; set;}        
        //}

        //public class RouterModel
        //{
        //    public int? Id { get; set; }
        //    public string Road { get; set; }
        //    public string Carrier { get; set; }
        //    public int? Сonsumption { get; set; }
        //}

        //public class ConsumptionModel
        //{
        //    public int Id { get; set; }
        //    public int? Loading { get; set; }
        //    public string Type { get; set; }
        //    public int? Consumption { get; set; }
        //    public string Method { get; set; }         
        //}
    }
}
