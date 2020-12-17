using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLQuanCafe.Helpers;
using Domain.Repositories;
using QLQuanCafe.ViewModels;
using Application.Interfaces;
using Application.DTOs;

namespace QLQuanCafe.Controllers
{
    public class NuocUongController : Controller
    {
        private readonly INuocUongService nuocUongService;

        public NuocUongController(INuocUongService nuocUongService)
        {
            this.nuocUongService = nuocUongService;
        }

        /*public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 10;
            int count;
            var nuocUongs = nuocUongService.GetNuocUongs(sortOrder, searchString, pageIndex, pageSize, out count);

            var indexVM = new NuocUongViewModel()
            {
                NuocUongs = new PaginatedList<NuocUongDto>(nuocUongs, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder
            };

            return View(indexVM);
        }*/

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 10;
            int count;
            var nuocUongs = nuocUongService.GetNuocUongs(sortOrder, searchString, pageIndex, pageSize, out count);

            var indexVM = new NuocUongViewModel()
            {
                NuocUongs = new PaginatedList<NuocUongDto>(nuocUongs, count, pageIndex, pageSize),
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
        public IActionResult Create(NuocUongDto nuocUong)
        {
            if (ModelState.IsValid)
            {
                nuocUongService.CreateNuocUong(nuocUong);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var nuocUong = nuocUongService.GetNuocUongs(id);

            return View(nuocUong);
        }

        [HttpPost]
        public IActionResult Edit(NuocUongDto nuocUong)
        {
            if (ModelState.IsValid)
            {
                nuocUongService.UpdateNuocUong(nuocUong);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var nuocUong = nuocUongService.GetNuocUongs(id);

            return View(nuocUong);
        }

        public IActionResult Delete(int id)
        {
            var nuocUong = nuocUongService.GetNuocUongs(id);

            return View(nuocUong);
        }

        [HttpPost]
        public IActionResult Delete(int id, bool notUsed)
        {
            nuocUongService.DeleteNuocUong(id);

            return RedirectToAction("Index");
        }
    }
}