using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<IngredientDto> GetIngredients(string sortOrder, string IngredientType, string searchString, int pageIndex, int pageSize, out int count );

        IngredientDto GetIngredient(int IngredientId);
        IEnumerable<string> GetTypes();
        void CreateIngredient(IngredientDto Ingredient);
        void UpdateIngredient(IngredientDto Ingredient);
        void DeleteIngredient(int IngredientId);
    }
}