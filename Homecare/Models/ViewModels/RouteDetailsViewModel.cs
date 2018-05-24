using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homecare.Models.ViewModels
{
    public class RouteDetailsViewModel
    {
        [Required(ErrorMessage = "Du skal skrive et tidspunkt")]
        [DisplayName("Tid")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm")]
        public string arrival { get; set; }
        [Required(ErrorMessage = "Vælg patient")]
        [DisplayName("Patient")]
        public string patientName { get; set; }
    }
}