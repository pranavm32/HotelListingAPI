// <auto-generated />
using HotelListingAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelListingAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220213132215_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HotelListingAPI.Data.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "India",
                            ShortName = "IND"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Japan",
                            ShortName = "JP"
                        },
                        new
                        {
                            Id = 3,
                            Name = "NewZealand",
                            ShortName = "NZ"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Australia",
                            ShortName = "AUS"
                        });
                });

            modelBuilder.Entity("HotelListingAPI.Data.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Mumbai",
                            CountryId = 1,
                            Name = "Taj Hotel",
                            Rating = 5.0
                        },
                        new
                        {
                            Id = 2,
                            Address = "Mumbai",
                            CountryId = 1,
                            Name = "Oberoi Hotel",
                            Rating = 5.0
                        },
                        new
                        {
                            Id = 3,
                            Address = "Sydney",
                            CountryId = 3,
                            Name = "Grand Palladium",
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 4,
                            Address = "Auckland",
                            CountryId = 4,
                            Name = "Reniassance Hotel",
                            Rating = 4.0
                        });
                });

            modelBuilder.Entity("HotelListingAPI.Data.Hotel", b =>
                {
                    b.HasOne("HotelListingAPI.Data.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
