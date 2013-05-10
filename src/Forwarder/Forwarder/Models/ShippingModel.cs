using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forwarder.Models
{
    public class ShippingModel
    {
        public string RegNumber { get; set; }
        public string ContainerNumber  { get; set; }
        public string InvoiceNumber  { get; set; } 
        public string Weight  { get; set; }
        public string Capacity  { get; set; }
        public string Date  { get; set; }
        public string ArriveDate  { get; set; }
    }
}