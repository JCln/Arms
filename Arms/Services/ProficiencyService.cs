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
    public interface IProficiencyService
    {
        Proficiency Get(int id);
        ICollection<Proficiency> Get();
        void Add(string title);
        void Remove(int id);
    }
    public class ProficiencyService : IProficiencyService
    {
        private readonly DbSet<Proficiency> _proficiencies;
        private readonly ArmsDbContext _context;
        public ProficiencyService(ArmsDbContext context)
        {
            _context = context;
            _proficiencies = _context.Proficiencies;
        }
        public Proficiency Get(int id)
        {
            return _proficiencies.Where(b => b.Id == id).First();
        }
        public ICollection<Proficiency> Get()
        {
            var proficiencys = _proficiencies.Where(b => b.IsDeleted == 0).ToList();
            return proficiencys;
        }
        public void Add(string title)
        {
            Proficiency proficiency = new Proficiency()
            {
                IsDeleted = 0,
                Title = title
            };
            _proficiencies.Add(proficiency);
        }
        public void Remove(int id)
        {
            var proficiency = Get(id);
            proficiency.IsDeleted = 1;
        }
    }
}
