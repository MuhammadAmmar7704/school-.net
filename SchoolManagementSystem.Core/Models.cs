namespace SchoolManagementSystem.Core.Models
{
    public enum UserRole
    {
        Admin,
        Teacher,
        Student
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Student : User
    {
        public string RegistrationNumber { get; set; }
        public string Class { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Attendance> AttendanceRecords { get; set; }
    }

    public class Teacher : User
    {
        public List<string> Subjects { get; set; }
    }

    public class Admin : User
    {
    }

    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public bool Present { get; set; }
    }

    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Subject { get; set; }
        public string AssessmentType { get; set; } // Quiz, Assignment, Exam
        public double Score { get; set; }
        public double MaxScore { get; set; }
        public DateTime Date { get; set; }
    }

    public class FeeChallan
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
    }

    public class Payroll
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public double Amount { get; set; }
        public DateTime PayDate { get; set; }
        public string Status { get; set; }
    }

    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; } // Meeting, Holiday, etc.
    }

    public class Badge
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AwardedDate { get; set; }
    }

    public class Assignment
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<Submission> Submissions { get; set; }
    }

    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string FileUrl { get; set; }
        public DateTime SubmittedDate { get; set; }
        public double? Grade { get; set; }
    }
}
