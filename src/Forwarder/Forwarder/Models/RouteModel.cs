using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Models
{
    public class RouteModel
    {
        public int? Id { get; set; }
        public int? Expense { get; set; }

        public string RoadId { get; set; }
        public string CarrierId { get; set; }

        public IEnumerable<SelectListItem> Roads { get; set; }
        public IEnumerable<SelectListItem> Carriers { get; set; }
    }
}