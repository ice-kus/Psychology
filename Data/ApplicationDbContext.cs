using Microsoft.EntityFrameworkCore;
using Psychology.Data.Models;
using System.Linq;

namespace Psychology.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Criteria> Criteria { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<TestQuestion> TestQuestionAnswer { get; set; }
        public DbSet<PassageData> PassageData { get; set; }
        public DbSet<PassageDataQuestion> PassageDataQuestion { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestQuestion> TestQuestion { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
    }
}