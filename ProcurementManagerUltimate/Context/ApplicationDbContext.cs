using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Model;

namespace ProcurementManagerUltimate.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Methods>(x => x.HasData(
                new Methods { Method = "National Competitive Tendering", MethodsID = 1 },
                new Methods { Method = "Sole Sourcing", MethodsID = 2 },
                new Methods { Method = "Single sourcing", MethodsID = 3 },
                new Methods { Method = "Restrictive Tendering", MethodsID = 4 }
                ));

            builder.Entity<Sources>(x => x.HasData(
                new Sources { Source = "IGF", SourcesID = 1 },
                new Sources { Source = "District Assembly", SourcesID = 2 },
                new Sources { Source = "Grants and Loans", SourcesID = 3 },
                new Sources { Source = "GOG Funding", SourcesID = 4 }
                ));

            builder.Entity<Items>(x => x.HasData(
                new Items { Item = "Maize", ItemsID = 1, Unit = "Bag" },
                new Items { Item = "Rice", ItemsID = 2, Unit = "Bag" },
                new Items { Item = "Millet", ItemsID = 3, Unit = "Bag" },
                new Items { Item = "Desktop Computer (Set)", ItemsID = 4, Unit = "pcs" },
                new Items { Item = "Laptop Computer", ItemsID = 5, Unit = "pcs" },
                new Items { Item = "Office furniture", ItemsID = 6, Unit = "pcs" },
                new Items { Item = "Printer", ItemsID = 7, Unit = "pcs" },
                new Items { Item = "Vehicle", ItemsID = 8, Unit = "unit" },
                new Items { Item = "Software", ItemsID = 9, Unit = "n/a" },
                new Items { Item = "Service", ItemsID = 10, Unit = "n/a" }
                ));

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Sources> Sources { get; set; }

        public virtual DbSet<Items> Items { get; set; }

        public virtual DbSet<Methods> Methods { get; set; }

        public virtual DbSet<Contracts> Contracts { get; set; }

        public virtual DbSet<ContractParameters> ContractParameters { get; set; }

        public virtual DbSet<Timelines> Timelines { get; set; }

        public virtual DbSet<Suppliers> Suppliers { get; set; }
    }
}
