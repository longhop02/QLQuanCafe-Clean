using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class NuocUong
    {
        public int Id { get; set; }

        [Required]
        public string TenNU { get; set; }

        [Required]
        public int DonGia { get; set; }
    }
}