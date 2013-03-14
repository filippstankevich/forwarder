using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forwarder.Models;
using Trirand.Web.Mvc;
using ForwarderDAL.Repositories;



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
            
                           var list = new List<GridModel>

                           {

                               new GridModel{Id = 1, FirstName = "Александр", LastName = "Македонский", Email = "alex.mak@test.com"},

                               new GridModel {Id = 2, FirstName = "Иван", LastName = "Петров", Email = "ivan@test.com"},

                               new GridModel{Id = 3, FirstName = "Сергей", LastName = "Сидоров", Email = "sarg@test.com"},

                           };

 

                            var result = new  JsonResult()

                             {

                                 Data = new { page = 0, total = 1, records = list.Count, rows = list }

                             };


                            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                            return result;    
             
        }

        
      
    }

     
}
