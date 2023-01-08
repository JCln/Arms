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
    public interface IOffTypeService
    {
        OffType Get(int id);
        ICollection<OffType> Get();
        ICollection<OffType> GetAll();
        void Add(string title);
        void Remove(int id);
    }
    public class OffTypeService:IOffTypeService
    {
        private readonly DbSet<OffType> _offTypes;
        private readonly ArmsDbContext _context;
        public OffTypeService(ArmsDbContext context)
        {
            _context = context;
            _offTypes = _context.OffTypes;
        }
        public OffType Get(int id)
        {
            return _offTypes.Where(b => b.Id == id).First();
        }
        public ICollection<OffType> Get()
        {
            var offTypes = _offTypes.Where(b => b.IsDeleted == 0).ToList();
            return offTypes;
        }
        public ICollection<OffType> GetAll()
        {
            var offTypes = _offTypes.ToList();
            return offTypes;
        }
        public void Add(string title)
        {
            OffType offType = new OffType()
            {
                IsDeleted = 0,
                Title = title
            };
            _offTypes.Add(offType);
        }
        public void Remove(int id)
        {
            var offType = Get(id);
            offType.IsDeleted = 1;
        }
    }
}
