using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly SchoolDbContext _context;
        public AdminService(SchoolDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Admin> GetAllAdmins() => _context.Admins.ToList();
        public Admin? GetAdminById(int id) => _context.Admins.Find(id);
        public void AddAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
        }
        public void UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
        }
        public void DeleteAdmin(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
        }
    }

    public class TeacherService : ITeacherService
    {
        private readonly SchoolDbContext _context;
        public TeacherService(SchoolDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Teacher> GetAllTeachers() => _context.Teachers.ToList();
        public Teacher? GetTeacherById(int id) => _context.Teachers.Find(id);
        public void AddTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }
        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
        public void DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }
    }
}
