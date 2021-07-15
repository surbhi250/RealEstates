using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Display(Name = "Type Of Property")]
        public string TypeOfProperty { get; set; }

        [Display(Name = "Dimentions")]
        public string Dimentions { get; set; }

        [Display(Name = "State ")]
        public string State { get; set; }
        
        [Display(Name = "City ")]
        public string City { get; set; }
        
        [Display(Name = "PinCode ")]
        public string PinCode { get; set; }
        
        [Display(Name = "Rate ")]
        public string Rate { get; set; }


    }
}
