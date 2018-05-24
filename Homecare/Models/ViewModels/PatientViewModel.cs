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
        [Range(100000000, 9999999999, ErrorMessage = "CPR-nummer skal være ti cifre")]
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
        [Range(1000, 9999, ErrorMessage = "Postnummeret skal være på fire cifre")]
        public string zipCode { get; set; }

        [Required(ErrorMessage = "Udfyld telefonnummer til patient")]
        [DisplayName("Telefonnummer (Patient)")]
        [Range(10000000, 99999999, ErrorMessage = "Telefonnummer skal være på otte cifre")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "Udfyld telefonnummer til pårørende")]
        [DisplayName("Telefonnummer (Pårørende)")]
        [Range(10000000, 99999999, ErrorMessage = "Telefonnummer skal være på otte cifre")]
        public string relativePhonenumber { get; set; }
    }
}