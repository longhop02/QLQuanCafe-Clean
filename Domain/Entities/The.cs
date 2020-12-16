using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class The
    {
        public int Id { get; set; }

        [Required]
        public string TenThe { get; set; }

        [Required]
        public string TrangThai { get; set; }
    }
}