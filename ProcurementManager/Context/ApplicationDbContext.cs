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
            optionsBuilder.UseSqlite("Data Source=procurement.db;", x =>
            {
                x.SuppressForeignKeyEnforcement(false);
                x.UseRelationalNulls(true);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<Methods>(x => x.HasData(
                new Methods { Method = "National Competitive Tendering", MethodsID = 1 },
                new Methods { Method = "Sole Sourcing", MethodsID = 2 },
                new Methods { Method = "Request for quotation", MethodsID = 3 },
                new Methods { Method = "Price quotation", MethodsID = 4 },
                new Methods { Method = "Restrictive Tendering", MethodsID = 5 },
                new Methods { Method = "International Competitive Tendering", MethodsID = 6 },
                new Methods { Method = "Price quotation", MethodsID = 7 }
                ));

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Contracts> Contracts { get; set; }

        public virtual DbSet<ContractParameters> ContractParameters { get; set; }

        public virtual DbSet<Methods> Methods { get; set; }

        public virtual DbSet<Timelines> Timelines { get; set; }

    }
}
