using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Infrastructure.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly SchoolDbContext _context;
        public AttendanceService(SchoolDbContext context) { _context = context; }
        public void RecordAttendance(int studentId, DateTime date, bool present)
        {
            var record = new Attendance { StudentId = studentId, Date = date, Present = present };
            _context.Attendances.Add(record);
            _context.SaveChanges();
        }
        public IEnumerable<Attendance> GetAttendanceByStudent(int studentId) => _context.Attendances.Where(a => a.StudentId == studentId).ToList();
        public IEnumerable<Attendance> GetAttendanceByDate(DateTime date) => _context.Attendances.Where(a => a.Date.Date == date.Date).ToList();
        public IEnumerable<Attendance> GetAllAttendance() => _context.Attendances.ToList();
    }

    public class GradeService : IGradeService
    {
        private readonly SchoolDbContext _context;
        public GradeService(SchoolDbContext context) { _context = context; }
        public void AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }
        public IEnumerable<Grade> GetGradesByStudent(int studentId) => _context.Grades.Where(g => g.StudentId == studentId).ToList();
        public IEnumerable<Grade> GetGradesBySubject(string subject) => _context.Grades.Where(g => g.Subject == subject).ToList();
        public IEnumerable<Grade> GetAllGrades() => _context.Grades.ToList();
    }
}
