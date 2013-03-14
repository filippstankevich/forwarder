using ForwarderDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
