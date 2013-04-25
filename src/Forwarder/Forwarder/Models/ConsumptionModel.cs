using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forwarder.Models
{
    public class ConsumptionModel
    {
        public int Id { get; set; }
        public int? Loading { get; set; }
        public string Type { get; set; }
        public int? Consumption { get; set; }
        public string Method { get; set; }    
    }
}