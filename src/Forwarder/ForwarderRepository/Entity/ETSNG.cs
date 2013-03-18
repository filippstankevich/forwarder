using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForwarderDAL.Entity
{
    public class ETSNG
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Transportation> TransportationEntity { get; set; }
    }
}
