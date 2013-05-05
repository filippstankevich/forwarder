using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Transportation> Transportations { get; set; }
    }
}
