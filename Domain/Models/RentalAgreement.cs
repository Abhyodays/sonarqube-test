using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RentalAgreement
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="User mail not provided")]
        [DataType(DataType.EmailAddress)]
        public string UserMail { get; set; }
        [Required]
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage ="Total price not provided")]
        public double TotalPrice { get; set; }
    }
}
