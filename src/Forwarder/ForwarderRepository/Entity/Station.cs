using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForwarderDAL.Entity
{
    public class Station
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Введите название станции")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите код станции")]
        public string Code { get; set; }

        public ICollection<Transportation> TransportationByDestinationStation { get; set; }

        public ICollection<Transportation> TransportationBySourceStation { get; set; }
    }
}
