using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homecare.Models.ViewModels
{
    public class CaretakerViewModel
    {
        [Required]
        [Display(Name = "Fulde navn")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Dit kodeord skal bestå af mindst 3 og højst 20 tegn")]
        [Display(Name = "Kodeord")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Dit kodeord skal bestå af mindst 3 og højst 20 tegn")]
        [Compare("password", ErrorMessage = "Kodeord er ikke ens")]
        [Display(Name = "Gentag kodeord")]
        public string confirmPassword { get; set; }

        [Display(Name = "Brugerrettigheder")]
        [Required]
        public string user_rights { get; set; }
        
        [Display(Name = "Telefonnummer")]
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "Telefonnummer skal være på otte cifre")]
        [RegularExpression("^[0 - 9] + $", ErrorMessage = "Telefonnummer skal være tal")]
        public string phonenumber { get; set; }
    }
}