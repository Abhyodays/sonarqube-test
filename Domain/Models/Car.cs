using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Car model property not provided")]
        public string Model { get; set; }
        [Required(ErrorMessage ="Car maker property not provided")]
        public string Maker { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage ="Rental price must be positive value")]
        public double RentalPrice { get; set; }
        [Required(ErrorMessage ="Availability status not provided")]
        public AvailabilityStatus Availability { get; set; }
    }
}
