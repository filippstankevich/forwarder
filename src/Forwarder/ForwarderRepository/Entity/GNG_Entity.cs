using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ForwarderDAL.Entity
{
    //TODO: Почему название класса через подчеркивание. Исправить или аргументировать.
    public class GNG_Entity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        ICollection<TransportationEntity> TransportationEntity { get; set; }
    }
}
