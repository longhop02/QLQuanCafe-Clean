using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CustomerDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; } 

        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        public string CustomerName { get; set; }    

        [StringLength(10, MinimumLength = 9)]
        [Display(Name = "Phone number")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}")]
        [Required]
        public string CustomerPhoneNumber { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string CustomerAddress { get; set; }    
        
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        [Required]
        public string CustomerEmail { get; set; }
    }
}