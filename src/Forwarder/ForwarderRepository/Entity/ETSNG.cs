using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    public class ETSNG
    {
        [Key]
        public int ID { get; set; }

        public int GngId { get; set; }
        [ForeignKey("GngId")]
        public virtual GNG GNGs { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Transportation> TransportationEntity { get; set; }
    }
}
