using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Ingredient : EntityBase, IAggregateRoot
    {
    
        public string IngredientName { get; set; }
        
        public string IngredientSupplier { get; set; }

        public decimal IngredientPrice { get; set; }

        public int IngredientQuantity { get; set; }

        public string IngredientUnit { get; set; }
        
        public string IngredientType { get; set; }
    }
}