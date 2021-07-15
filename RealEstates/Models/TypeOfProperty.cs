using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    public class TypeOfProperty
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
