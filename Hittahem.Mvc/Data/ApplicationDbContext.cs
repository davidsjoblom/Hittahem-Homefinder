using Hittahem.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hittahem.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //relationerna för mellantabellen InterestedUsers
            builder.Entity<InterestedUser>()
                .HasKey(k => new { k.HomeId, k.UserId });

            builder.Entity<InterestedUser>()
                .HasOne(iu => iu.User)
                .WithMany(u => u.InterestedUsers)
                .HasForeignKey(iu => iu.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<InterestedUser>()
                .HasOne(iu => iu.Home)
                .WithMany(u => u.InterestedUsers)
                .HasForeignKey(iu => iu.HomeId)
                .OnDelete(DeleteBehavior.NoAction);

            //database seed for testing
            var seededUser = new ApplicationUser
            {
                Id = 1,
                UserName = "test@example.com",
                NormalizedUserName = "TEST@EXAMPLE.COM",
                Email = "test@example.com",
                NormalizedEmail = "TEST@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEP49exl7ynjFa5tsvI3t0wz+euWQTv/eYpnCmtMDS3hGw3LLkBSH+fWkAcenzVNsEA==",
                SecurityStamp = "2QIVNQYKHPKRPOXZPLLD24QJ242LMWLZ",
                ConcurrencyStamp = "3c27a053-4447-4aef-8220-95ff805603b0",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true
            };
            //PasswordHasher<ApplicationUser> passwordHasher = new();
            //seededUser.PasswordHash = passwordHasher.HashPassword(seededUser, @"Pa$$w0rd");
            builder.Entity<ApplicationUser>().HasData(seededUser);

            builder.Entity<HousingType>()
                .HasData(new HousingType
                {
                    Id=1,
                    Name = "Lägenhet"
                });
            builder.Entity<OwnershipType>()
                .HasData(new OwnershipType
                {
                    Id = 1,
                    Name = "Bostadsrätt"
                });
            builder.Entity<Municipality>()
                .HasData(new Municipality
                {
                    Id = 1,
                    Name = "Stockholm"
                });
            builder.Entity<Street>()
                .HasData(new Street
                {
                    Id = 1,
                    Name = "Stockholmsvägen"
                });
            builder.Entity<Home>()
                .HasData(new Home
                {
                    Id = 1,
                    Price = 1000000,
                    Description = "Fett trevligt jag svär",
                    Rooms = 1,
                    LivingArea = 18.5m,
                    TimePosted = DateTime.UtcNow,
                    StreetNr = "69",
                    StreetId = 1,
                    UserId = 1,
                    MunicipalityId = 1,
                    HousingTypeId = 1,
                    OwnershipTypeId = 1
                });
            builder.Entity<HomeViewing>()
                .HasData(new HomeViewing
                {
                    Id = 1,
                    Date = DateTime.Now,
                    HomeId = 1
                });
        }

        public DbSet<Home> Homes { get; set; } = null!;
        public DbSet<HomeImage> HomeImages { get; set; } = null!;
        public DbSet<HomeViewing> HomeViewings { get; set; } = null!;
        public DbSet<HousingType> HousingTypes { get; set; } = null!;
        public DbSet<Municipality> Municipalities { get; set; } = null!;
        public DbSet<OwnershipType> OwnershipTypes { get; set; } = null!;
        public DbSet<Street> Streets { get; set; } = null!;
    }
}