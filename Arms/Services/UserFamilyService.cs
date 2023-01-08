using Arms.Data;
using Arms.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Arms.Services
{
    public interface IUserFamilyService
    {
        ICollection<UserFamily> Get(string userNationalId);
        UserFamily Get(int id);
        ICollection<UserFamily> Get();
        void Add(UserFamily userFamily);
        void Remove(int id);
    }
    public class UserFamilyService : IUserFamilyService
    {
        private readonly DbSet<UserFamily> _userFamilies;
        private readonly ArmsDbContext _context;
        public UserFamilyService(ArmsDbContext context)
        {
            _context = context;
            _userFamilies = _context.UserFamilies;
        }
        public UserFamily Get(int id)
        {
            return _userFamilies.Where(b => b.Id == id).First();
        }
        public ICollection<UserFamily> Get(string userNationalId)
        {
            return _userFamilies
                .Where(u => u.UserNationalId == userNationalId && u.IsDeleted==0)
                .ToList();
        }
        public ICollection<UserFamily> Get()
        {
            var userFamilies = _userFamilies.Where(b => b.IsDeleted == 0).ToList();
            return userFamilies;
        }
        public void Add(UserFamily userFamily)
        {  
            _userFamilies.Add(userFamily);
        }
        public void Remove(int id)
        {
            var userFamily = Get(id);
            userFamily.IsDeleted = 1;
        }
    }
}
