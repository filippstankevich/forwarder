using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForwarderDAL.Entity;

namespace Forwarder.Models
{
    public class TransportationModel
    {
        public IEnumerable<SelectListItem> GngItems { get; set; }
        public IEnumerable<SelectListItem> EtsngItems { get; set; }
        public IEnumerable<SelectListItem> StationItems { get; set; }

        public string Gng { get; set; }
        public string Etsng { get; set; }
        public string SourceStation { get; set; }
        public string DestinationStation { get; set; }
        public string RegNumber {get; set;}
        public string Comment {get; set;}
    }
}