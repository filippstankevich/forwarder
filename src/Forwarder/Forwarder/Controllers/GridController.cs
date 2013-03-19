using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Controllers
{
    public class GridController : Controller
    {
        //
        // GET: /Grid/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GridView()
        {
            var list = new List<object>
                {
                    new {
                            id = 1,
                            cell = new string[]
                               {
                                    "1",
                                    "12345",
                                    "Томск",
                                    "Москва",
                                    "123",
                                    "321",
                                    "8",
                                    "100",
                                    "ок",
                                    "1.01.2012"
                                }
                    }
                };

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
            public string TransportCount { get; set; }
            public string FullWeight { get; set; }
            public string Comments { get; set; }
            public string RegDate { get; set; }
 

        }

    }
}
