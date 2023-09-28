using System.ComponentModel.DataAnnotations;

namespace LNTU_GuideMap.Data.Models {
    public class Map {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(10000000)]
        public byte[]? Image { get; set; }
    }
}
