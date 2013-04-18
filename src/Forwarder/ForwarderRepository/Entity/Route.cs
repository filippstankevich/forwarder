using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        public int RoadId { get; set; }
        [ForeignKey("RoadId")]
        public virtual Road Roads { get; set; }

        public int CarrierId { get; set; }
        [ForeignKey("CarrierId")]
        public virtual Carrier Carriers { get; set; }

        public int LoadingId { get; set; }
        [ForeignKey("LoadingId")]
        public virtual Loading Loadings { get; set; }

        public virtual ICollection<Outgo> OutgoEntity { get; set; }
    }
}
