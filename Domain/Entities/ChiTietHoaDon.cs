using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ChiTietHoaDon
    {
        public int Id { get; set; }

        [Required]
        public int IdHD { get; set; }

        [Required]
        public int IdNU { get; set; }

        [Required]
        public int SoLuong { get; set; }

        [Required]
        public int TongTien { get; set; }
    }
}