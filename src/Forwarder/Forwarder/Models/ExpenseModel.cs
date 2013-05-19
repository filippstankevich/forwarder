using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace Forwarder.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; } //Transportation id

        [Required(ErrorMessage = "Выберите значение")]
        public int ExpenseId { get; set; }

        public int RouteId { get; set; }

        [Required(ErrorMessage = "Выберите загрузку")]
        public int LoadId { get; set; }

        public string ExpenseTypeId { get; set; }

        [Required(ErrorMessage = "Введите значение расходов")]
        [Integer(ErrorMessage = "Значение вводимое в поле \"Расход\" должно быть целым числом")]
        public int? Expense { get; set; }

        [Required(ErrorMessage = "Выберите метод расчета")]
        public bool Method { get; set; }

        public IEnumerable<SelectListItem> ExpenseTypes { get; set; }
        public IEnumerable<SelectListItem> Methods { get; set; }
        public IEnumerable<SelectListItem> Loads { get; set; }
    }
}