using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForwarderDAL.Entity
{
    public class Etsng
    {
        [Key]
        public int Id { get; set; }

        //public int GngId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Transportation> TransportationEntity { get; set; }
    }
}
