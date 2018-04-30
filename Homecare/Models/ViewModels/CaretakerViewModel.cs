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
        public string name { get; set; }
        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Dit kodeord skal bestå af mindst 3 og højst 20 tegn")]
        public string password { get; set; }
        [Required]
        public string user_rights { get; set; }
        [Required]
        public string phonenumber { get; set; }
    }
}