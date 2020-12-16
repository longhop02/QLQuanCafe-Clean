using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class HoaDon
    {
        public int Id { get; set; }

        [Required]
        public string TaiKhoan { get; set; }

        [DataType(DataType.Date)]
        public DateTime NgayLap { get; set; }
        
        [Required]
        public int TongTien { get; set; }

        [Required]
        public int GiamGia { get; set; }

        [Required]
        public int ThanhTien { get; set; }

        [Required]
        public int TrangThai { get; set; }
    }
}