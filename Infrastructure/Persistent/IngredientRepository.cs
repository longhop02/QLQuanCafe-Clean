using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistent
{
    public class IngredientRepository : EFRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(QLQuanCafeContext context) : base(context)
        {
        }

        public IEnumerable<string> GetIngredientTypes()
        {
            return context.Ingredients
                            .OrderBy(m => m.IngredientType)
                            .Select(m => m.IngredientType)
                            .Distinct();
        }

        public IEnumerable<Ingredient> IngredientFilter(string sortOrder, string ingredientIngredientType, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.Ingredients.AsQueryable();

            if (!string.IsNullOrEmpty(ingredientIngredientType))
            {
                query = query.Where(m => m.IngredientType == ingredientIngredientType);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.IngredientName.Contains(searchString));
            }

            SortIngredients(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortIngredients(string sortOrder, ref IQueryable<Ingredient> query)
        {
            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(m => m.IngredientName);
                    break;
                case "name":
                    query = query.OrderBy(m => m.IngredientName);
                    break;
                case "supplier_desc":
                    query = query.OrderByDescending(m => m.IngredientSupplier);
                    break;
                case "supplier":
                    query = query.OrderBy(m => m.IngredientSupplier);
                    break;
                case "IngredientPrice_desc":
                    query = query.OrderByDescending(m => m.IngredientPrice);
                    break;
                case "IngredientPrice":
                    query = query.OrderBy(m => m.IngredientPrice);
                    break;
                case "unit_desc":
                    query = query.OrderByDescending(m => m.IngredientUnit);
                    break;
                case "unit":
                    query = query.OrderBy(m => m.IngredientUnit);
                    break;
                case "quantity_desc":
                    query = query.OrderByDescending(m => m.IngredientQuantity);
                    break;
                case "quantity":
                    query = query.OrderBy(m => m.IngredientQuantity);
                    break;    
                case "type_desc":
                    query = query.OrderByDescending(m => m.IngredientType);
                    break;
                case "type":
                    query = query.OrderBy(m => m.IngredientType);
                    break;
            }
        }
    }
}