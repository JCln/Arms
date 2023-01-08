using Arms.Data;
using Arms.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Arms.Services
{
    public interface IJobService
    {
        Job Get(int id);
        ICollection<Job> Get();
        void Add(string title);
        void Remove(int id);
    }
    public class JobService : IJobService
    {
        private readonly DbSet<Job> _jobs;
        private readonly ArmsDbContext _context;
        public JobService(ArmsDbContext context)
        {
            _context = context;
            _jobs = _context.Jobs;
        }
        public Job Get(int id)
        {
            return _jobs.Where(b => b.Id == id).First();
        }
        public ICollection<Job> Get()
        {
            var jobs = _jobs.Where(b => b.IsDeleted == 0).ToList();
            return jobs;
        }
        public void Add(string title)
        {
            Job job = new Job()
            {
                IsDeleted = 0,
                Title = title
            };
            _jobs.Add(job);
        }
        public void Remove(int id)
        {
            var job = Get(id);
            job.IsDeleted = 1;
        }
    }
}
