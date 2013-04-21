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

        private IForwarderRepository repository = IoCContainer.GetRepository();

        //
        // GET: /Grid/

        public ActionResult Index()
        {
            return View(new List<Station>() { new Station() { Code = "1", Id = 1, Name = "name" } });
        }

        public ActionResult NewView()
        {
            return PartialView(new List<Station>() {new Station() {Code = "1", Id = 1, Name = "name"}});
        }
        
        public PartialViewResult PartView()
        {
            var model = new StationModel
                {
                    Station = new Station {Code = "QWERTYUIOP", Id = 1, Name = "ASDFGHJKL"},
                    Result = "ЧТОТО"
                };
            return PartialView("PartView", model);
        }

        public JsonResult GridView(string RegNumber, string DispatchStation, string ArriveStattion,
                                   string GHGClassificator, string ETSNGClassificator, string RegDate)
        {
            IList<Transportation> transporatations = repository.Transportations.ToList();

            IEnumerable<GridModel> resultList = transporatations.Select(t => new GridModel() 
            {
                RegNumber = t.RegNumber, 
                DispatchStation = t.DestinationStation.Name,
                ArriveStattion = t.SourceStation.Name
            }); 

            //var result = new List<GridModel>();
            //var gridRow1 = new GridModel() {RegNumber = "123", DispatchStation = "2", ArriveStattion = "1"};
            //var gridRow2 = new GridModel() {RegNumber = "124", DispatchStation = "3", ArriveStattion = "2"};
            //var gridRow3 = new GridModel() {RegNumber = "125", DispatchStation = "4", ArriveStattion = "5"};
            //result.Add(gridRow1);
            //result.Add(gridRow2);
            //result.Add(gridRow3);
            
            if (!string.IsNullOrEmpty(RegNumber))
                resultList = resultList.Where(d => d.RegNumber.Contains(RegNumber)).ToList();
            if (!string.IsNullOrEmpty(DispatchStation))
                resultList = resultList.Where(d => d.DispatchStation.Contains(DispatchStation)).ToList();
            if (!string.IsNullOrEmpty(ArriveStattion))
                resultList = resultList.Where(d => d.ArriveStattion.Contains(ArriveStattion)).ToList();
            if (!string.IsNullOrEmpty(GHGClassificator))
                resultList = resultList.Where(d => d.GHGClassificator.Contains(GHGClassificator)).ToList();
            if (!string.IsNullOrEmpty(ETSNGClassificator))
                resultList = resultList.Where(d => d.ETSNGClassificator.Contains(ETSNGClassificator)).ToList();
            if (!string.IsNullOrEmpty(RegDate))
                resultList = resultList.Where(d => d.RegDate == RegDate).ToList();

            var list = new List<object>();
            var counter = 0;

            foreach (var item in resultList)
            {
                list.Add(new
                    {
                        id = ++counter,
                        cell = new string[]
                            {
                                (counter + 1).ToString(),
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
            //var list = new List<object>
            //    {

            //        new {
            //                id = 1,
            //                cell = new string[]
            //                   {
            //                        listnew[0].ArriveStattion.ToString(),
            //                        "12345",
            //                        "Томск",
            //                        "Москва",
            //                        "123",
            //                        "321",
            //                        "8",
            //                        "100",
            //                        "ок",
            //                        "1.01.2012"
            //                    }
            //        },
            //        new {
            //                id = 2,
            //                cell = new string[]
            //                   {
            //                        "2",
            //                        "12345",
            //                        "новосиб",
            //                        "Москва",
            //                        "32323",
            //                        "321",
            //                        "9",
            //                        "100",
            //                        "ок",
            //                        "2.01.2012"
            //                    }
            //        },
            //        new {
            //                id = 3,
            //                cell = new string[]
            //                   {
            //                        "3",
            //                        "12345",
            //                        "Красноярск",
            //                        "Москва",
            //                        "32323",
            //                        "321",
            //                        "10",
            //                        "200",
            //                        "ок",
            //                        "3.01.2012"
            //                    }
            //        }
            //    };
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

        public class GridModel
        {
            public int Id { get; set; }
            public string RegNumber { get; set; }
            public string DispatchStation { get; set; }
            public string ArriveStattion { get; set; }
            public string GHGClassificator { get; set; }
            public string ETSNGClassificator { get; set; }
            public int? TransportCount { get; set; }
            public string FullWeight { get; set; }
            public string Comments { get; set; }
            public string RegDate { get; set; }
        }
    }
}
