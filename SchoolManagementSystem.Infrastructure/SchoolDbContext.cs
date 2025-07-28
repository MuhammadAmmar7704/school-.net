using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Infrastructure
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<FeeChallan> FeeChallans { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add model configuration here if needed
        }
    }
}
