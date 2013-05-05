using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    [Table("Stations")]
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название станции")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите код станции")]
        public string Code { get; set; }

        public ICollection<Transportation> TransportationsByDestinationStation { get; set; }

        public ICollection<Transportation> TransportationsBySourceStation { get; set; }
    }
}
