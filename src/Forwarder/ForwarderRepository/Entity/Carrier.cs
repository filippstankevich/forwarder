using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForwarderDAL.Entity
{
    public class Carrier
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Route> RouteEntity { get; set; }
    }
}
