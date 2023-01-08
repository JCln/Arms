using Arms.Data;
using Arms.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Arms.Services
{
    public interface ILoanService
    {
        Loan Get(int id);
        ICollection<Loan> Get();
        ICollection<Loan> Get(string personnelCode);
        void Add(Loan loan);
        void Remove(int id);
    }
    public class LoanService : ILoanService
    {
        private readonly DbSet<Loan> _loans;
        private readonly ArmsDbContext _context;
        public LoanService(ArmsDbContext context)
        {
            _context = context;
            _loans = _context.Loans;
        }
        public Loan Get(int id)
        {
            return _loans.Where(b => b.Id == id).First();
        }
        public ICollection<Loan> Get(string personnelCode)
        {
            return _loans.Where(b => b.PersonnelId == personnelCode && b.IsDeleted==0).ToList();
        }
        public ICollection<Loan> Get()
        {
            var courses = _loans.Where(b => b.IsDeleted == 0).ToList();
            return courses;
        }
        public void Add(Loan loan)
        {            
            _loans.Add(loan);
        }
        public void Remove(int id)
        {
            var loan = Get(id);
            loan.IsDeleted = 1;
        }
    }
}
