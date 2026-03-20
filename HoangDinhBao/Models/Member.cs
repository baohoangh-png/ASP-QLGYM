using System.ComponentModel.DataAnnotations;

namespace HoangDinhBao.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(255)]
        public string? QRCode { get; set; } // Có thể null vì lúc mới tạo chưa kịp sinh mã QR

        public bool IsActive { get; set; } = true; // True = Active, False = Inactive

        // Mối quan hệ 1-Nhiều: 1 Hội viên có thể có nhiều Gói đăng ký và nhiều Lượt check-in
        public ICollection<Subscription>? Subscriptions { get; set; }
        public ICollection<CheckInLog>? CheckInLogs { get; set; }
    }
}