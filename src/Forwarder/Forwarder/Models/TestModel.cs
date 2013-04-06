using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forwarder.Models
{
    public class TestModel
    {
        //[Required(ErrorMessage="Enter name")]
        //[Display(Name="Test field")]
        //public string Name = "Тестовая строка";

        //[Display(Name = "Success???")]
        //public string Result;
        public IEnumerable<string> Stations { get; set; } 
    }
}