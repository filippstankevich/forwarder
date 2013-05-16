using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Models
{
    public class LoadModel
    {
        public int Id { get; set; } //TransportationId

        public int LoadId { get; set; }

        [Required(ErrorMessage = "Введите вес груза на еденицу транспорта")]
        //[Range(0, 1000, ErrorMessage = "Выходит за пределы допустимых значений")]
        public int Volume { get; set; }

        [Required(ErrorMessage = "Введите ставку оплаты")]
        //[Range(0, 1000, ErrorMessage = "Выходит за пределы допустимых значений")]
        public int Rate { get; set; }

        public int Expense { get; set; }
        
        [Required(ErrorMessage = "Выберите значение")]
        public bool Method { get; set; }

        [Required(ErrorMessage = "Введите количество едениц транспорта")]
        //[Range(0, 1000, ErrorMessage = "Выходит за пределы допустимых значений")]
        public int Count { get; set; }

        public IEnumerable<SelectListItem> Methods { get; set; }
    }
}