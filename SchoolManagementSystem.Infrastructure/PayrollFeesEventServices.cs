using SchoolManagementSystem.Core.Interfaces;
using SchoolManagementSystem.Core.Models;

namespace SchoolManagementSystem.Infrastructure.Services
{
    public class FeeService : IFeeService
    {
        private readonly SchoolDbContext _context;
        public FeeService(SchoolDbContext context) { _context = context; }
        public void GenerateFeeChallan(int studentId, double amount, DateTime dueDate)
        {
            var challan = new FeeChallan { StudentId = studentId, Amount = amount, DueDate = dueDate, Paid = false };
            _context.FeeChallans.Add(challan);
            _context.SaveChanges();
        }
        public IEnumerable<FeeChallan> GetFeeChallansByStudent(int studentId) => _context.FeeChallans.Where(f => f.StudentId == studentId).ToList();
        public void MarkFeeAsPaid(int challanId, DateTime paidDate)
        {
            var challan = _context.FeeChallans.Find(challanId);
            if (challan != null) { challan.Paid = true; challan.PaidDate = paidDate; _context.SaveChanges(); }
        }
        public IEnumerable<FeeChallan> GetAllFeeChallans() => _context.FeeChallans.ToList();
    }

    public class PayrollService : IPayrollService
    {
        private readonly SchoolDbContext _context;
        public PayrollService(SchoolDbContext context) { _context = context; }
        public void GeneratePayroll(int staffId, double amount, DateTime payDate)
        {
            var payroll = new Payroll { StaffId = staffId, Amount = amount, PayDate = payDate, Status = "Pending" };
            _context.Payrolls.Add(payroll);
            _context.SaveChanges();
        }
        public IEnumerable<Payroll> GetPayrollsByStaff(int staffId) => _context.Payrolls.Where(p => p.StaffId == staffId).ToList();
        public IEnumerable<Payroll> GetAllPayrolls() => _context.Payrolls.ToList();
    }

    public class EventService : IEventService
    {
        private readonly SchoolDbContext _context;
        public EventService(SchoolDbContext context) { _context = context; }
        public void AddEvent(Event ev)
        {
            _context.Events.Add(ev);
            _context.SaveChanges();
        }
        public IEnumerable<Event> GetAllEvents() => _context.Events.ToList();
        public Event? GetEventById(int id) => _context.Events.Find(id);
        public void UpdateEvent(Event ev)
        {
            _context.Events.Update(ev);
            _context.SaveChanges();
        }
        public void DeleteEvent(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev != null) { _context.Events.Remove(ev); _context.SaveChanges(); }
        }
    }
}
