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

        public JsonResult GridView(string RegNumber, string DispatchStation, string ArriveStattion,
                                   string GHGClassificator, string ETSNGClassificator, DateTime RegDate)
        {
            var listresult1 = repository.Transportations.ToList();
            
            if (!string.IsNullOrEmpty(RegNumber))
                listresult1 = listresult1.Where(d => d.RegNumber.Contains(RegNumber)).ToList();
            if (!string.IsNullOrEmpty(DispatchStation))
                listresult1 = listresult1.Where(d => d.DestinationStations.Name.Contains(DispatchStation)).ToList();
            if (!string.IsNullOrEmpty(ArriveStattion))
                listresult1 = listresult1.Where(d => d.SourceStations.Name.Contains(ArriveStattion)).ToList();
            if (!string.IsNullOrEmpty(GHGClassificator))
                listresult1 = listresult1.Where(d => d.Gngs.Code.Contains(GHGClassificator)).ToList();
            if (!string.IsNullOrEmpty(ETSNGClassificator))
                listresult1 = listresult1.Where(d => d.Etsngs.Code.Contains(ETSNGClassificator)).ToList();
            if (RegDate != null)
                listresult1 = listresult1.Where(d => d.CreateDate == RegDate).ToList();

            var list = new List<object>();
            var counter = 0;

            foreach (var item in listresult1)
            {
                list.Add(new
                    {
                        id = ++counter,
                        cell = new string[]
                            {
                                (counter + 1).ToString(),
                                !string.IsNullOrEmpty(item.RegNumber) ? item.RegNumber : string.Empty,
                                item.DestinationStations != null ? item.DestinationStations.Name : string.Empty,
                                item.SourceStations != null ? item.SourceStations.Name : string.Empty,
                                item.Gngs != null ? item.Gngs.Code : string.Empty,
                                item.Etsngs != null ? item.Etsngs.Code : string.Empty,
                                item.CreateDate != null ? item.CreateDate.ToString() : string.Empty,
                                // TODO: Сделать подсчет транспорта и коментарий
                                // item.TransportCount != null ? item.TransportCount.Value.ToString() : string.Empty,
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
