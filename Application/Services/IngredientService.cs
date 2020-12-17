using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public IEnumerable<IngredientDto> GetIngredients(string sortOrder, string ingredientType, string searchString, int pageIndex, int pageSize, out int count)
        {
            var ingredients = ingredientRepository.IngredientFilter(sortOrder, ingredientType, searchString, pageIndex, pageSize, out count);

            return ingredients.MappingDtos();
        }

        public IngredientDto GetIngredient(int ingredientId)
        {
            var ingredient = ingredientRepository.GetBy(ingredientId);

            return ingredient.MappingDto();
        }

        public IEnumerable<string> GetTypes()
        {
            return ingredientRepository.GetIngredientTypes();
        }

        public void CreateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = ingredientDto.MappingIngredient();
            ingredientRepository.Add(ingredient);
        }

        public void UpdateIngredient(IngredientDto ingredientDto)
        {
            var ingredient = ingredientRepository.GetBy(ingredientDto.Id);

            ingredientDto.MappingIngredient(ingredient);

            ingredientRepository.Update(ingredient);
        }

        public void DeleteIngredient(int ingredientId)
        {
            var ingredient = ingredientRepository.GetBy(ingredientId);

            ingredientRepository.Delete(ingredient);
        }
    }
}