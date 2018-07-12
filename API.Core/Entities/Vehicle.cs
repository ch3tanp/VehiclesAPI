using API.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace API.Core.Entities
{
    public class Vehicle : BaseEntity
    {

        [Required]
        [Range(1950, 2050, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int Year { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Length of {0} must be between {2} and {1}")]
        public string Make { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Length of {0} must be between {2} and {1}")]
        public string Model { get; set; }
    }
}
