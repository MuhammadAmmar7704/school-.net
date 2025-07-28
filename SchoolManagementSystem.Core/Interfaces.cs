using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Core.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }

    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        void BulkUploadStudents(IEnumerable<Student> students);
        IEnumerable<Student> FilterStudents(string @class, string subject, string grade);
    }

    public interface IAttendanceService
    {
        void RecordAttendance(int studentId, DateTime date, bool present);
        IEnumerable<Attendance> GetAttendanceByStudent(int studentId);
        IEnumerable<Attendance> GetAttendanceByDate(DateTime date);
        IEnumerable<Attendance> GetAllAttendance();
    }

    public interface IGradeService
    {
        void AddGrade(Grade grade);
        IEnumerable<Grade> GetGradesByStudent(int studentId);
        IEnumerable<Grade> GetGradesBySubject(string subject);
        IEnumerable<Grade> GetAllGrades();
    }

    public interface IFeeService
    {
        void GenerateFeeChallan(int studentId, double amount, DateTime dueDate);
        IEnumerable<FeeChallan> GetFeeChallansByStudent(int studentId);
        void MarkFeeAsPaid(int challanId, DateTime paidDate);
        IEnumerable<FeeChallan> GetAllFeeChallans();
    }

    public interface IPayrollService
    {
        void GeneratePayroll(int staffId, double amount, DateTime payDate);
        IEnumerable<Payroll> GetPayrollsByStaff(int staffId);
        IEnumerable<Payroll> GetAllPayrolls();
    }

    public interface IEventService
    {
        void AddEvent(Event ev);
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        void UpdateEvent(Event ev);
        void DeleteEvent(int id);
    }

    public interface IAssignmentService
    {
        void AddAssignment(Assignment assignment);
        IEnumerable<Assignment> GetAssignmentsByTeacher(int teacherId);
        IEnumerable<Assignment> GetAllAssignments();
        void AddSubmission(Submission submission);
        IEnumerable<Submission> GetSubmissionsByAssignment(int assignmentId);
    }

    public interface IBadgeService
    {
        void AwardBadge(Badge badge);
        IEnumerable<Badge> GetBadgesByStudent(int studentId);
        IEnumerable<Badge> GetAllBadges();
    }

    // Interfaces for AI, Notification, and Integration hooks can be added here
}
