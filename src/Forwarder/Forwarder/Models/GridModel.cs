using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forwarder.Models
{
    public class GridModel
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public string DispatchStation { get; set; }
        public string ArriveStattion { get; set; }
        public string GHGClassificator { get; set; }
        public string ETSNGClassificator { get; set; }
        public int? TransportCount { get; set; }
        public string FullWeight { get; set; }
        public string Comments { get; set; }
        public string RegDate { get; set; }
    }
}