using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Infrastructure.Services
{
    // Example implementation for IUserService (others follow similar pattern)
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public User? Authenticate(string username, string password)
        {
            // Password hashing/validation omitted for brevity
            return _users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
        }

        public void AddUser(User user) => _users.Add(user);
        public void DeleteUser(int id) => _users.RemoveAll(u => u.Id == id);
        public IEnumerable<User> GetAllUsers() => _users;
        public User? GetUserById(int id) => _users.FirstOrDefault(u => u.Id == id);
        public void UpdateUser(User user)
        {
            var idx = _users.FindIndex(u => u.Id == user.Id);
            if (idx >= 0) _users[idx] = user;
        }
    }

    public class StudentService : IStudentService
    {
        private readonly SchoolDbContext _context;
        public StudentService(SchoolDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents() => _context.Students.ToList();
        public Student? GetStudentById(int id) => _context.Students.Find(id);
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
        public void BulkUploadStudents(IEnumerable<Student> students)
        {
            _context.Students.AddRange(students);
            _context.SaveChanges();
        }
        public IEnumerable<Student> FilterStudents(string @class, string subject, string grade)
        {
            // Filtering logic can be expanded as needed
            return _context.Students.Where(s =>
                (string.IsNullOrEmpty(@class) || s.Class == @class)
            ).ToList();
        }
    }
}
