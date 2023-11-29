using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Models.Lists;
using MyProject.Models.realstates;
using MyProject.Models.RealStates;
using MyProject1.Models.RealStates;

namespace MyProject1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WishListItem>().HasKey(t => new { t.WishListId, t.RealStatesId });
            modelBuilder.Entity<CompoundAmenities>().HasKey(p => new { p.AmenitiesId, p.CompoundId });
            modelBuilder.Entity<Amenitiees>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Compound>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Developer>().HasIndex(t => t.Name).IsUnique();
        }
        public DbSet<WishList> WishLists { get; set; }
       public DbSet<RealEState> RealEStates { get; set; }
        public DbSet<Developer> Developers { get; set; }
       public DbSet<Compound> Compounds { get; set; }
        public DbSet<Photo> Photos { get; set; }
       public DbSet<Amenitiees> Amenities { get; set; }
       public DbSet<RealEStateType> RealEStateTypes { get; set; }
       public DbSet<WishListItem> WishListItems { get; set; }
     public DbSet<CompoundAmenities> CompoundAmenities { get; set; }
        public DbSet<PaymentPlanForCompound> PaymentPlansForCompound { get; set; }
        public DbSet<PaymentPlanForRealEState> PaymentPlansForRealEState { get; set; }

    }
}