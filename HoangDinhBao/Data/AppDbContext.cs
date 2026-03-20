using Microsoft.EntityFrameworkCore;
using HoangDinhBao.Models;

namespace HoangDinhBao.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Khai báo 4 bảng dữ liệu cho hệ thống Gym
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CheckInLog> CheckInLogs { get; set; }
    }
}