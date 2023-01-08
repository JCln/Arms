using Arms.Data;
using Arms.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Arms.Services
{
    public interface ITanbihiTashviqiService
    {
        TanbihiTashviqi Get(int id);
        ICollection<TanbihiTashviqi> Get();
        ICollection<TanbihiTashviqi> Get(string personnelCode, bool isTanbihi);
        void Add(TanbihiTashviqi tashTan);
        void Remove(int id);
    }
    public class TanbihiTashviqiService : ITanbihiTashviqiService
    {
        private readonly DbSet<TanbihiTashviqi> _tashTans;
        private readonly ArmsDbContext _context;
        public TanbihiTashviqiService(ArmsDbContext context)
        {
            _context = context;
            _tashTans = _context.TashviqiTanbihies;
        }
        public TanbihiTashviqi Get(int id)
        {
            return _tashTans.Where(b => b.Id == id).First();
        }
        public ICollection<TanbihiTashviqi> Get(string personnelCode, bool isTanbihi)
        {
            int isTanbihiCode = isTanbihi ? 1 : 0;
            return _tashTans
                .Where(b => b.PersonnelId == personnelCode && b.IsDeleted==0 && b.IsTanbihi==isTanbihiCode)
                .ToList();
        }
        public ICollection<TanbihiTashviqi> Get()
        {
            var tashTans = _tashTans.Where(b => b.IsDeleted == 0).ToList();
            return tashTans;
        }
        public void Add(TanbihiTashviqi tashTan)
        {            
            _tashTans.Add(tashTan);
        }
        public void Remove(int id)
        {
            var tashTan = Get(id);
            tashTan.IsDeleted = 1;
        }
    }
}
