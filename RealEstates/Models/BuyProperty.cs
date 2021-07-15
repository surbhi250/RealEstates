using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class BuyProperty
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Contact ")]
        public string Contact { get; set; }

        [Display(Name = "Type Of Property")]
        public int PropertyId { get; set; }

        [Display(Name = "Dimentions")]
        public string Dimentions { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Pin Code")]
        public string PinCode { get; set; }
    }
}
