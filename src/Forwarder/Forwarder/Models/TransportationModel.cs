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
        public LoadModel Loaders;

        public int Id { get; set; }
        public string GngId { get; set; }
        public string EtsngId { get; set; }
        public string SourceStationId { get; set; }
        public string DestinationStationId { get; set; }
        public string RegNumber {get; set;}
        public string Comment {get; set;}

        public int PlannedExpense { get; set; }
        public int PlannedPrice { get; set; }
        public int PlannedProfit { get; set; }

        public int RealExpense { get; set; }
        public int RealPrice { get; set; }
        public int RealProfit { get; set; }
    }
}