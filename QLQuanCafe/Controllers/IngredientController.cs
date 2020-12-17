using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLQuanCafe.Helpers;
using QLQuanCafe.ViewModels;
using Application.Interfaces;
using Application.DTOs;

namespace QLQuanCafe.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        public IActionResult Index(string sortOrder, string ingredientType, string searchString, int pageIndex = 1)
        {
            int pageSize = 10;
            int count;
            var ingredients = ingredientService.GetIngredients(sortOrder, ingredientType, searchString, pageIndex, pageSize, out count );
            var types = ingredientService.GetTypes();

            var indexVM = new IngredientViewModel()
            {
                Ingredients = new PaginatedList<IngredientDto>(ingredients, count, pageIndex, pageSize),
                Types = new SelectList(types),
                IngredientType = ingredientType,
                SearchString = searchString,
                SortOrder = sortOrder
            };

            return View(indexVM);
        }
        public IActionResult Create()
        {            
            return View();
        }


        [HttpPost]
        public IActionResult Create(IngredientDto ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredientService.CreateIngredient(ingredient);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var ingredient = ingredientService.GetIngredient(id);

            return View(ingredient);
        }

        [HttpPost]
        public IActionResult Edit(IngredientDto ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredientService.UpdateIngredient(ingredient);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var ingredient = ingredientService.GetIngredient(id);

            return View(ingredient);
        }

        public IActionResult Delete(int id)
        {
            var ingredient = ingredientService.GetIngredient(id);

            return View(ingredient);
        }

        [HttpPost]
        public IActionResult Delete(int id, bool notUsed)
        {
            ingredientService.DeleteIngredient(id);

            return RedirectToAction("Index");
        }
    }
}