using onlineGrades.Core.Entity;
using System.Data.Entity;

namespace onlineGrades.Core.Configuration.EF_Configuration
{
    public class DataBaseManagement : DbContext
    {
        public DataBaseManagement() : base("myConn")
        {

        }

        public DbSet<Categorie> Categorii { get; set; }
        public DbSet<Curs> Cursuri { get; set; }
        public DbSet<Nota> Note { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Profesor> Profesori { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
