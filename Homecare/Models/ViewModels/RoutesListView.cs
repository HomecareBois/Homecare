using Homecare.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homecare.Models.ViewModels
{
    public class RoutesListView
    {
        [Required(ErrorMessage = "Du skal vælge en hjemmehjælper")]
        public Caretaker Caretaker { get; set; }

        [Required(ErrorMessage = "Du skal skrive en dato")]
        [DisplayName("Dato")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string date { get; set; }
    }
}