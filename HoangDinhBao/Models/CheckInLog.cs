using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoangDinhBao.Models
{
    public class CheckInLog
    {
        [Key]
        public int LogId { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member? Member { get; set; }

        public DateTime CheckInTime { get; set; } = DateTime.Now;

        public int BranchId { get; set; }
    }
}