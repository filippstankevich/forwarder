using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; } //Transportation id

        public int ExpenseId { get; set; }

        public int RouteId { get; set; }

        public int LoadId { get; set; }

        public string ExpenseTypeId { get; set; }

        public int? Expense { get; set; }

        public bool Method { get; set; }

        public IEnumerable<SelectListItem> ExpenseTypes { get; set; }
        public IEnumerable<SelectListItem> Methods { get; set; }
        public IEnumerable<SelectListItem> Loads { get; set; }
    }
}