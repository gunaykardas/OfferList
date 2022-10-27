using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Offer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Mode { get; set; }
        [Required]
        public short MovementType { get; set; }
        [Required]
        public bool Incoterm { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PackageType { get; set; }
        [Required]
        public string Unit1 { get; set; }
        [Required]
        public double Unit1Value { get; set; }
        [Required]

        public string Unit2 { get; set; }
        [Required]
        public double Unit2Value { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public double Price { get; set; }


    }
}


