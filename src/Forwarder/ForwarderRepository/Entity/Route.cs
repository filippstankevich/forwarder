using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Routes")]
    public class Route
    {
        [Key]
        public int Id { get; set; }

        public int RoadId { get; set; }
        [ForeignKey("RoadId")]
        public virtual Road Road { get; set; }

        public int CarrierId { get; set; }
        [ForeignKey("CarrierId")]
        public virtual Carrier Carrier { get; set; }

        public int TransportationId { get; set; }
        [ForeignKey("TransportationId")]
        public virtual Transportation Transportation { get; set; }       

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
