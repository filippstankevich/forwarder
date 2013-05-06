using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForwarderDAL.Entity
{
    [Table("Shipments")]
    public class Shipment
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string BillNumber { get; set; }

        public string WagonNumber { get; set; }

        public int Weight { get; set; }

        public int Capacity { get; set; }

        public int TransportationId { get; set; }
        [ForeignKey("TransportationId")]
        public virtual Transportation Transportation { get; set; }
    }
}
