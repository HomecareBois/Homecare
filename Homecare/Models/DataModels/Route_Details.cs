//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Homecare.Models.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Route_Details
    {
        public int id_route_details { get; set; }
        [Required(ErrorMessage = "Du skal skrive et tidspunkt")]
        [DisplayName("Ankomst")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh.mm")]
        public System.TimeSpan arrival { get; set; }
        public int fk_route_route_details { get; set; }
        public int fk_patient_route_details { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Route Route { get; set; }
    }
}