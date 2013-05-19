using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace Forwarder.Models
{
    public class RouteModel
    {
        public int? RouteId { get; set; }
        public int? Id { get; set; } //TransportationId
        public int? Expense { get; set; }
        [Required(ErrorMessage = "Выберите значение")]
        public string RoadId { get; set; }
        [Required(ErrorMessage = "Выберите значение")]
        public string CarrierId { get; set; }

        public IEnumerable<SelectListItem> Roads { get; set; }
        public IEnumerable<SelectListItem> Carriers { get; set; }
    }
}