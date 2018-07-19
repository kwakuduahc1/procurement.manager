using Microsoft.EntityFrameworkCore;
using ProcurementManager.Model;

namespace ProcurementManager.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=assistant.db;", x =>
            {
                x.SuppressForeignKeyEnforcement(false);
                x.UseRelationalNulls(true);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Methods>(x => x.HasData(
            //    new Subjects { Subject = "Public Health Nursing", SubjectsID = 1, SubjectCode = "001" },
            //    new Subjects { Subject = "Basic Infection Prevention and Control", SubjectsID = 2, SubjectCode = "002" }
            //    ));

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Contracts> Contracts { get; set; }

        public virtual DbSet<ContractParameters> ContractParameters { get; set; }

        public virtual DbSet<Methods> Methods { get; set; }

        public virtual DbSet<Timelines> Timelines { get; set; }

    }
}
