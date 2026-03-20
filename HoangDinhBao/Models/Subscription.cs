using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoangDinhBao.Models
{
    public class Subscription
    {
        [Key]
        public int SubId { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member? Member { get; set; }

        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public Membership? Membership { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? RemainingSessions { get; set; }
    }
}