using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Etsngs")]
    public class Etsng
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Transportation> Transportations { get; set; }
    }
}
