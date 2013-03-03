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

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Stations
            .Select(x => x.Name);
            
            return PartialView(categories);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
