using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Models
{
    public class LoadModel
    {
        public int Id { get; set; } //TransportationId

        public int LoadId { get; set; }

        public int Volume { get; set; }
        public int Rate { get; set; }
        public int Expense { get; set; }
        public bool Method { get; set; }
        public int Count { get; set; }

        public IEnumerable<SelectListItem> Methods { get; set; }
    }
}