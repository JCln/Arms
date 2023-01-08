using Arms.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arms.Data
{
    public class ArmsDbContext:DbContext
    {
        public ArmsDbContext(): base("armsDb")
            //base("armsDb")
        {
            var path = AppDomain.CurrentDomain.BaseDirectory+ "\\Db\\armsDb.sqlite";
            Database.SetInitializer<ArmsDbContext>(null);
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<ArmsDbContext>(modelBuilder);
        //    Database.SetInitializer(sqliteConnectionInitializer);
        //}
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<UserFamily> UserFamilies { get; set; }
        public DbSet<OffType> OffTypes { get; set; }      
        public DbSet<Loan> Loans { get; set; }  
        public DbSet<TanbihiTashviqi> TashviqiTanbihies { get; set; }
    }
}
