using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Models
{
    public class TransportationModel
    {
        public IEnumerable<SelectListItem> GngItems { get; set; }
        public IEnumerable<SelectListItem> EtsngItems { get; set; }
        public IEnumerable<SelectListItem> StationItems { get; set; }
    }
}