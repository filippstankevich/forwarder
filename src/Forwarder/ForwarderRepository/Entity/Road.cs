using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Roads")]
    public class Road
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}
