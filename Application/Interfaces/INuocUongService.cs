using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface INuocUongService
    {
        IEnumerable<NuocUongDto> GetNuocUongs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count );

        NuocUongDto GetNuocUongs(int NuocUongId);
        void CreateNuocUong(NuocUongDto NuocUong);
        void UpdateNuocUong(NuocUongDto NuocUong);
        void DeleteNuocUong(int NuocUongId);
    }
}