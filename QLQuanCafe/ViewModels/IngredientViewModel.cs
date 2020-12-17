using Microsoft.AspNetCore.Mvc.Rendering;
using QLQuanCafe.Helpers;
using Application.DTOs;

namespace QLQuanCafe.ViewModels
{
    public class IngredientViewModel
    {
        public PaginatedList<IngredientDto> Ingredients { get; set; }
        public SelectList Types { get; set; }
        public string IngredientType { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }

    
}