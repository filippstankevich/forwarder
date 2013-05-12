using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forwarder.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int LoadId { get; set; }

        public int? Load { get; set; }

        public string ExpenseTypeId { get; set; }

        public int? Expense { get; set; }

        public string Method { get; set; }

        public int Value { get; set; }

        public IEnumerable<SelectListItem> ExpenseTypes { get; set; }
        public IEnumerable<SelectListItem> Methods { get; set; }
    }
}