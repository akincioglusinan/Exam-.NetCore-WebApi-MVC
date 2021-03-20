using System.IO;
using Microsoft.EntityFrameworkCore;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.DataAccess.Concrete.Base
{
    public class SqLiteDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=db\\ExamProject.db"); //@"Data Source=..\SinavProje.Entities\Concrete\Entities\Base\ExamProject.db"
    }
}
