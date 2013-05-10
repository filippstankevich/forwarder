using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Expenses")]
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }

        public int LoadId { get; set; }
        [ForeignKey("LoadId")]
        public virtual Load Load { get; set; }

        public int ExpenseTypeId { get; set; }
        [ForeignKey("ExpenseTypeId")]
        public ExpenseType ExpenseType { get; set; }

        public bool Method { get; set; } // true - плата за тонну, false - за вагон

        public int Value { get; set; }
    }
}
