using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace Forwarder.Models
{
    public class LoadModel
    {
        public int Id { get; set; } //TransportationId

        public int LoadId { get; set; }

        [Required(ErrorMessage = "Введите вес груза на еденицу транспорта")]
        //[Range(0, int.MaxValue, ErrorMessage = "Выходит за пределы допустимых значений")]
        [Min(0, ErrorMessage = "Минимальный вес груза должен быть положительным числом.")]
        [Integer(ErrorMessage = "Значение вводимое в поле \"Загрузка\" должно быть целым положительным числом")]
        public int Volume { get; set; }

        [Required(ErrorMessage = "Введите ставку оплаты")]
        [Min(0, ErrorMessage = "Минимальная ставка оплаты должна быть положительным числом.")]
        [Integer(ErrorMessage = "Значение вводимое в поле \"Ставка\" должно быть целым положительным числом")]
        //[Range(0, 1000, ErrorMessage = "Выходит за пределы допустимых значений")]
        public int Rate { get; set; }

        public int Expense { get; set; }
        
        [Required(ErrorMessage = "Выберите значение")]
        public bool Method { get; set; }

        [Required(ErrorMessage = "Введите количество едениц транспорта")]
        [Integer(ErrorMessage = "Значение вводимое в поле \"Количество\" должно быть целым положительным числом")]
        [Min(0, ErrorMessage = "Минимальное количество транспорта должно быть положительным числом.")]
        //[Range(0, 1000, ErrorMessage = "Выходит за пределы допустимых значений")]
        public int Count { get; set; }

        public IEnumerable<SelectListItem> Methods { get; set; }
    }
}