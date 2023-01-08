using Arms.Data;
using Arms.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arms.Services
{
    public interface IBankService
    {
        Bank Get(int id);
        ICollection<Bank> Get();
        void Add(string title);
        void Remove(int id);
    }
    public class BankService:IBankService
    {
        private readonly DbSet<Bank> _banks;
        private readonly ArmsDbContext _context;
        public BankService(ArmsDbContext context)
        {
            _context = context;
            _banks = _context.Banks;
        }
        public Bank Get(int id)
        {
            return _banks.Where(b => b.Id == id).First();
        }
        public ICollection<Bank> Get()
        {
            var banks = _banks.Where(b => b.IsDeleted == 0).ToList();
            return banks;
        }
        public void Add(string title)
        {
            Bank bank = new Bank()
            {
                IsDeleted = 0,
                Title = title
            };
            _banks.Add(bank);
        }
        public void Remove(int id)
        {
            var bank = Get(id);
            bank.IsDeleted = 1;
        }
    }
}
