using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class NuocUongService : INuocUongService
    {
        private readonly INuocUongRepository nuocUongRepository;

        public NuocUongService(INuocUongRepository nuocUongRepository)
        {
            this.nuocUongRepository = nuocUongRepository;
        }

        public IEnumerable<NuocUongDto> GetNuocUongs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var nuocUongs = nuocUongRepository.NuocUongSearch(sortOrder, searchString, pageIndex, pageSize, out count);
            //var customers = customerRepository.CustomerSearch(sortOrder, searchString,out count);


            return nuocUongs.MappingDtos();
        }

        public NuocUongDto GetNuocUongs(int nuocUongId)
        {
            var nuocUong = nuocUongRepository.GetBy(nuocUongId);

            return nuocUong.MappingDto();
        }


        public void CreateNuocUong(NuocUongDto nuocUongDto)
        {
            var nuocUong = nuocUongDto.MappingNuocUong();
            nuocUongRepository.Add(nuocUong);
        }

        public void UpdateNuocUong(NuocUongDto nuocUongDto)
        {
            var nuocUong = nuocUongRepository.GetBy(nuocUongDto.Id);

            nuocUongDto.MappingNuocUong(nuocUong);

            nuocUongRepository.Update(nuocUong);
        }

        public void DeleteNuocUong(int nuocUongId)
        {
            var nuocUong = nuocUongRepository.GetBy(nuocUongId);

            nuocUongRepository.Delete(nuocUong);
        }

        public IEnumerable<NuocUongDto> GetNuocUongs(string sortOrder, string NuocUongType, string searchString, int pageIndex, int pageSize, out int count)
        {
            throw new System.NotImplementedException();
        }

        public NuocUongDto GetNuocUong(int NuocUongId)
        {
            throw new System.NotImplementedException();
        }
    }
}