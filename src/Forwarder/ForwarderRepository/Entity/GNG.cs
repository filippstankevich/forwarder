using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForwarderDAL.Entity
{
    public class Gng
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Transportation> TransportationEntity { get; set; }
    }
}
