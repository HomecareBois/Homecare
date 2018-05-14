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

        [Required(ErrorMessage = "Du skal skrive en dato")]
        [DisplayName("Dato")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Du skal skrive et tidspunkt")]
        [DisplayName("Tid")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh.mm")]
        public DateTime time { get; set; }

        [Required]
        [DisplayName("CPR-nummer")]
        public string patientCpr { get; set; }
        
    }
}