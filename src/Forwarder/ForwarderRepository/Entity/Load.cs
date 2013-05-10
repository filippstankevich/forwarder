using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Loads")]
    public class Load
    {
        [Key]
        public int Id { get; set; }

        public int Volume { get; set; }

        public int Rate { get; set; }

        public bool Method { get; set; } // true - плата за тонну, false - за вагон

        public int Count { get; set; }

        public int TransportationId { get; set; }
        [ForeignKey("TransportationId")]
        public virtual Transportation Transportation { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
