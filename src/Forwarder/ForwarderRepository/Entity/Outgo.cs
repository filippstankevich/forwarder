using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    public class Outgo
    {
        [Key]
        public int Id { get; set; }

        public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route Routes { get; set; }

        public string OutgoType { get; set; }
        public int OutgoValue { get; set; }


    }
}
