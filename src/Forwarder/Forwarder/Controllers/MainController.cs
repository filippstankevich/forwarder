using ForwarderDAL.Entity;
using ForwarderDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forwarder.Models;

namespace Forwarder.Controllers
{
    public class MainController : Controller
    {
        private IForwarderRepository repository;

        public MainController(IForwarderRepository repo)
        {
            repository = repo;
        }

        public ViewResult Menu()
        {
            IEnumerable<string> stations = repository.Stations
            .Select(x => x.Name);
            
            return ViewResult(stations);
        }

        private ViewResult ViewResult(IEnumerable<string> stations)
        {
            var testModel = new TestModel(){Stations = stations};
            return View(testModel);
        }
        
        public PartialViewResult StationAdd()
        {
            var model = new StationModel {Station = new Station {Code = "QWERTYUIOP", ID = 1, Name = "ASDFGHJKL"}, Result = "ЧТОТО"};
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult StationAdd(StationModel model)
        {
            var newStation = new Station();
            newStation.Name = model.Station.Name;
            newStation.Code = model.Station.Code;
            newStation.ID = model.Station.ID;
            var flag = repository.AddNewStation(newStation);
            model.Result = flag ? "Успешно" : "Не удалось";
            var newModel = new StationModel()
                {
                    Station = model.Station,
                    Result = model.Result
                };
            return PartialView("StationAdd", newModel);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
