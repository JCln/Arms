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
    public interface ICourseService
    {
        Course Get(int id);
        ICollection<Course> Get();
        void Add(string title);
        void Remove(int id);
    }
    public class CourseService:ICourseService
    {
        private readonly DbSet<Course> _courses;
        private readonly ArmsDbContext _context;
        public CourseService(ArmsDbContext context)
        {
            _context = context;
            _courses = _context.Courses;
        }
        public Course Get(int id)
        {
            return _courses.Where(b => b.Id == id).First();
        }
        public ICollection<Course> Get()
        {
            var courses = _courses.Where(b => b.IsDeleted == 0).ToList();
            return courses;
        }
        public void Add(string title)
        {
            Course course = new Course()
            {
                IsDeleted = 0,
                Title = title
            };
            _courses.Add(course);
        }
        public void Remove(int id)
        {
            var course = Get(id);
            course.IsDeleted = 1;
        }
    }
}
