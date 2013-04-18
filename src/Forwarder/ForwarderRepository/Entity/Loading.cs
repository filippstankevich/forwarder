using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    public class Loading
    {
        [Key]
        public int Id { get; set; }

        public int TransportationId { get; set; }

        [ForeignKey("TransportationId")]
        public virtual Transportation Transportations { get; set; }

        public int Value { get; set; }
        public int Rate { get; set; }

        public bool Metod { get; set; }
        public int Count { get; set; }

        public virtual ICollection<Route> RouteEntity { get; set; }
    }
}
