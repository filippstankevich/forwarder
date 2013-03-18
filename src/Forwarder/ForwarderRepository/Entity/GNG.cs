using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForwarderDAL.Entity
{
    public class GNG
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Transportation> TransportationEntity { get; set; }
    }
}
