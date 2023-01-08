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
    public interface IBadgeService
    {
        Badge Get(int id);
        ICollection<Badge> Get();
        void Add(string title);
        void Remove(int id);
    }
    public class BadgeService : IBadgeService
    {
        private readonly DbSet<Badge> _badges;
        private readonly ArmsDbContext _context;
        public BadgeService(ArmsDbContext context)
        {
            _context = context;
            _badges = _context.Badges;
        }
        public Badge Get(int id)
        {
            return _badges.Where(b => b.Id == id).First();
        }
        public ICollection<Badge> Get()
        {
            var badges = _badges.Where(b => b.IsDeleted == 0).ToList();
            return badges;
        }
        public void Add(string title)
        {
            Badge badge = new Badge()
            {
                IsDeleted = 0,
                Title = title
            };
            _badges.Add(badge);
        }
        public void Remove(int id)
        {
            var badge = Get(id);
            badge.IsDeleted = 1;
        }
    }
}
