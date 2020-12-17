using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class IngredientDto
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Display(Name = "Name")]
        [Required]
        public string IngredientName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Display(Name = "Supplier")]
        [Required]
        public string IngredientSupplier { get; set; }           

        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]
        public decimal IngredientPrice { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Quantity")]
        public int IngredientQuantity { get; set; } 

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(10, MinimumLength = 1)]
        [Display(Name = "Unit")]
        [Required]
        public string IngredientUnit { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Display(Name = "Type")]
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string IngredientType { get; set; }
    }
}