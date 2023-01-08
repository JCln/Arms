using Arms.Data;
using Arms.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Arms.Services
{
    public interface IEducationService
    {
        Education Get(int id);
        ICollection<Education> Get();
        void Add(string title);
        void Remove(int id);
    }
    public class EducationService : IEducationService
    {
        private readonly DbSet<Education> _educations;
        private readonly ArmsDbContext _context;
        public EducationService(ArmsDbContext context)
        {
            _context = context;
            _educations = _context.Educations;
        }
        public Education Get(int id)
        {
            return _educations.Where(b => b.Id == id).First();
        }
        public ICollection<Education> Get()
        {
            var educations = _educations.Where(b => b.IsDeleted == 0).ToList();
            return educations;
        }
        public void Add(string title)
        {
            Education education = new Education()
            {
                IsDeleted = 0,
                Title = title
            };
            _educations.Add(education);
        }
        public void Remove(int id)
        {
            var education = Get(id);
            education.IsDeleted = 1;
        }
    }
}
