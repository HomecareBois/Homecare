using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homecare.Models.ViewModels
{
    public class RouteViewModel
    {
        [Required(ErrorMessage = "Vælg en hjemmehjælper")]
        [DisplayName("Hjemmehjælper")]
        public string caretaker { get; set; }

        [Required(ErrorMessage = "")]
        [DisplayName("Hjemmehjælper")]
        public DateTime date { get; set; }

        public DateTime time { get; set; }

        public string patientCpr { get; set; }
        
    }
}