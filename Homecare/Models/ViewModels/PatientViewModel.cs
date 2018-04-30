using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homecare.Models.ViewModels
{
    public class PatientViewModel
    {
        [Required(ErrorMessage = "Udfyld navn")]
        [DisplayName("Navn")]
        public string name { get; set; }

        [Required(ErrorMessage = "Udfyld CPR-nummer")]
        [DisplayName("CPR")]
        public string cpr { get; set; }

        [Required(ErrorMessage = "Udfyld gadenavn")]
        [DisplayName("Gadenavn")]
        public string roadname { get; set; }

        [Required(ErrorMessage = "Udfyld hus nr")]
        [DisplayName("Hus nr")]
        public string number { get; set; }

        [Required(ErrorMessage = "Udfyld by")]
        [DisplayName("By")]
        public string cityName { get; set; }

        [Required(ErrorMessage = "Udfyld postnummer")]
        [DisplayName("Postnummer")]
        public string zipCode { get; set; }

        [Required(ErrorMessage = "Udfyld telefonnummer til patient")]
        [DisplayName("Telefonnummer (Patient)")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "Udfyld telefonnummer til pårørende")]
        [DisplayName("Telefonnummer (Pårørende)")]
        public string relativePhonenumber { get; set; }
    }
}