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
    public interface IUserCourseService
    {
        UserCourse Get(int id);
        ICollection<UserCourse> Get();
        ICollection<UserCourse> Get(string nationalId);
        void Add(UserCourse userCourse);
        void Remove(int id);
    }
    public class UserCourseService : IUserCourseService
    {
        private readonly DbSet<UserCourse> _userCourses;
        private readonly ArmsDbContext _context;
        public UserCourseService(ArmsDbContext context)
        {
            _context = context;
            _userCourses = _context.UserCourses;
        }
        public UserCourse Get(int id)
        {
            return _userCourses.Where(b => b.Id == id).First();
        }
        public ICollection<UserCourse> Get()
        {
            var badges = _userCourses.Where(b => b.IsDeleted == 0).ToList();
            return badges;
        }
        public ICollection<UserCourse> Get(string nationalId)
        {
            var badges = _userCourses
                .Where(b => b.NationalId==nationalId && b.IsDeleted == 0)
                .ToList();
            return badges;
        }
        public void Add(UserCourse userCourse)
        {
            _userCourses.Add(userCourse);
        }
        public void Remove(int id)
        {
            var badge = Get(id);
            badge.IsDeleted = 1;
        }
    }
}
