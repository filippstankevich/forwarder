using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions;
using ForwarderDAL.Entity;

namespace Forwarder.Models
{
    public class TransportationModel
    {
        public IEnumerable<SelectListItem> GngItems { get; set; }
        public IEnumerable<SelectListItem> EtsngItems { get; set; }
        public IEnumerable<SelectListItem> StationItems { get; set; }
        public LoadModel Loaders;

        public string Id { get; set; }
        [Required(ErrorMessage = "Выберите значение")]
        public string GngId { get; set; }
        [Required(ErrorMessage = "Выберите значение")]
        public string EtsngId { get; set; }
        [Required(ErrorMessage = "Выберите станцию отправления")]
        public string SourceStationId { get; set; }
        [Required(ErrorMessage = "Выберите станцию назначения")]
        public string DestinationStationId { get; set; }
        [Numeric(ErrorMessage = "Регистрационный номер должен быть числом")]
        [Required(ErrorMessage = "Введите регистрацинный номер")]
        public string RegNumber {get; set;}
        public string Comment {get; set;}

        public int PlannedExpense { get; set; }
        public int PlannedPrice { get; set; }
        public int PlannedProfit { get; set; }

        public int RealExpense { get; set; }
        public int RealPrice { get; set; }
        public int RealProfit { get; set; }

        //// Добавлены в виде хаков
        //public bool OpenDialogEx { get; set; }
        //public int RoutId { get; set; }
    }
}