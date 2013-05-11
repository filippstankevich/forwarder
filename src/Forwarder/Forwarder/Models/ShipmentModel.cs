using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forwarder.Models
{
    public class ShipmentModel
    {
        public string Id { get; set; }

        public string RegNumber { get; set; }
        public string ContainerNumber  { get; set; }
        public string InvoiceNumber  { get; set; } 
        public string Weight  { get; set; }
        public string Capacity  { get; set; }
        public DateTime Date  { get; set; }
        public DateTime ArriveDate  { get; set; }
    }
}