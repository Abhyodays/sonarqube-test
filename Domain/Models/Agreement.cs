﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Agreement:RentalAgreement
    {
        [Required]
        public AgreementStatus Status { get; set; }
    }
}
