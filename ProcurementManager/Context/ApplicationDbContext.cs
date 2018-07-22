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

            builder.Entity<Sources>(x => x.HasData(
                new Sources { Source = "IGF", SourcesID = 1 },
                new Sources { Source = "District Assembly", SourcesID = 2 },
                new Sources { Source = "Grants and Loans", SourcesID = 3 }
                ));

            builder.Entity<Items>(x => x.HasData(
                new Items { Item = "Foodstuff", ItemsID = 1, ShortName = "FDS" },
                new Items { Item = "Electronics", ItemsID = 2, ShortName = "ELT" },
                new Items { Item = "Stationery", ItemsID = 3, ShortName = "STN" }
                ));

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Sources> Sources { get; set; }
        
        public virtual DbSet<Items> Items { get; set; }

        public virtual DbSet<Methods> Methods { get; set; }

        public virtual DbSet<Contracts> Contracts { get; set; }

        public virtual DbSet<ContractParameters> ContractParameters { get; set; }

        public virtual DbSet<Timelines> Timelines { get; set; }
    }
}
