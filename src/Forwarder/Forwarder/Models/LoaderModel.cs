using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forwarder.Models
{
    public class LoaderModel
    {
        public int? Id { get; set; }
        public int? Loading { get; set; }
        public int? Rate { get; set; }
        public int? Сonsumption { get; set; }
        public string Method { get; set; }
        public int? Count { get; set; }    
    }
}