using Microsoft.AspNetCore.Mvc.Rendering;
using QLQuanCafe.Helpers;
using Application.DTOs;

namespace QLQuanCafe.ViewModels
{
    public class NuocUongViewModel
    {
        public PaginatedList<NuocUongDto> NuocUongs { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }

}