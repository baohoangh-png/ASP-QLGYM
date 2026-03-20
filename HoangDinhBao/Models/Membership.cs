using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Thêm dòng này để dùng được [Column]

namespace HoangDinhBao.Models
{
    public class Membership
    {
        [Key]
        public int PackageId { get; set; }

        [Required]
        [StringLength(100)]
        public string PackageName { get; set; } = string.Empty;

        public int DurationInDays { get; set; }

        // Khai báo rõ: Tổng cộng tối đa 18 chữ số, trong đó có 2 chữ số thập phân
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public bool AllowBranch { get; set; }

        public ICollection<Subscription>? Subscriptions { get; set; }
    }
}