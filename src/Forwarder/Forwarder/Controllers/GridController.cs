using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public JsonResult GridView()
        {
            string search = Request.Params["_search"]; //Булево значение, если запрос с условием поиска оно принимает истинное значение
            string filters =  Request.Params["filters"]; // Объект с условиями в представлении json;
            string searchField =  Request.Params["searchField"]; // Имя поля для поиска (если условие простое);
            string searchOper =  Request.Params["searchOper"]; //Операция сравнения поля для поиска (если условие простое);
            string searchString = Request.Params["searchString"]; // Значение поля для поиска (если условие простое);
            
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
                    },
                    new {
                            id = 2,
                            cell = new string[]
                               {
                                    "2",
                                    "12345",
                                    "новосиб",
                                    "Москва",
                                    "32323",
                                    "321",
                                    "9",
                                    "100",
                                    "ок",
                                    "2.01.2012"
                                }
                    },
                    new {
                            id = 3,
                            cell = new string[]
                               {
                                    "3",
                                    "12345",
                                    "Красноярск",
                                    "Москва",
                                    "32323",
                                    "321",
                                    "10",
                                    "200",
                                    "ок",
                                    "3.01.2012"
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
