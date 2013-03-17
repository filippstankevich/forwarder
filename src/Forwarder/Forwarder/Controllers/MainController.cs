﻿using ForwarderDAL.Entity;
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

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Stations
            .Select(x => x.Name);
            
            return PartialView(categories);
        }
        
        public PartialViewResult StationAdd()
        {
            var model = new StationModel {Station = new Station {Code = "QWERTYUIOP", ID = 1, Name = "ASDFGHJKL"}};
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
            return PartialView(model);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
