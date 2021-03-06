using System.ComponentModel.DataAnnotations;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class NuocUong : EntityBase, IAggregateRoot
    {
        public int Id { get; set; }

        [Required]
        public string TenNU { get; set; }

        [Required]
        public int DonGia { get; set; }
    }
}