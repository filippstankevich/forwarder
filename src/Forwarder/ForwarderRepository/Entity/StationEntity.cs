using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ForwarderDAL.Entity
{
    //TODO: Filipp Stankevich Зачем использовать в названия POCO-классов слово Entity. 
    //Мне кажеться в этом нет необходимости
    public class StationEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        ICollection<TransportationEntity> TransportationEntity {get;set;}
    }
}
