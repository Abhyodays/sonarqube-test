using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public enum AvailabilityStatus
    {
        [Display(Name="Available")]
        Available,
        [Display(Name ="Not Available")]
        NotAvailable,
        [Display(Name ="Under Inspection")]
        UnderInspection
    }
}
