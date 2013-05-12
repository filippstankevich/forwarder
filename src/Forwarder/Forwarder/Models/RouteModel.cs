using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Models
{
    public class RouteModel
    {
        public int? RouteId { get; set; }
        public int? Id { get; set; } //TransportationId
        public int? Expense { get; set; }

        public int? RoadId { get; set; }
        public int? CarrierId { get; set; }

        public IEnumerable<SelectListItem> Roads { get; set; }
        public IEnumerable<SelectListItem> Carriers { get; set; }
    }
}