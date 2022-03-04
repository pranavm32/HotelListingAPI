using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data
{
    public class DatabaseContext: IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name= "India",
                    ShortName = "IND"
                },
                new Country
                {
                    Id = 2,
                    Name = "Japan",
                    ShortName = "JP"

                },
                new Country
                {
                    Id = 3,
                    Name = "NewZealand",
                    ShortName = "NZ"

                },
                new Country
                {
                    Id = 4,
                    Name = "Australia",
                    ShortName = "AUS"

                }
              );

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Taj Hotel",
                    Address = "Mumbai",
                    Rating = 5.0,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Oberoi Hotel",
                    Address = "Mumbai",
                    Rating = 5.0,
                    CountryId = 1

                },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand Palladium",
                    Address = "Sydney",
                    Rating = 4.0,
                    CountryId = 3

                },
                new Hotel
                {
                    Id = 4,
                    Name = "Reniassance Hotel",
                    Address = "Auckland",
                    Rating = 4.0,
                    CountryId = 4

                }
              );
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        // public DbSet<ApiUser> Hotels { get; set; }
    }
}
