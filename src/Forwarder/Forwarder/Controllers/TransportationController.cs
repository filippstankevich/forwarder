using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forwarder.Models;

namespace Forwarder.Controllers
{
    public class TransportationController : Controller
    {
        //
        // GET: /Transportation/

        public ActionResult Index()
        {
            TransportationModel model = new TransportationModel();
           
            //TODO: Fake
            model.GngItems = new SelectListItem[] 
            { 
                new SelectListItem(){Text = "1", Value = "1"},
                new SelectListItem(){Text = "2", Value = "2"}
            };

            model.EtsngItems = new SelectListItem[] 
            { 
                new SelectListItem(){Text = "1", Value = "1"},
                new SelectListItem(){Text = "2", Value = "2"}
            };

            model.StationItems = new SelectListItem[] 
            { 
                new SelectListItem(){Text = "1", Value = "1"},
                new SelectListItem(){Text = "2", Value = "2"}
            };
            //------

            return View(model);
        }

        [HttpPost]
        public void Save(TransportationModel model)
        {
            
        }

    }
}
