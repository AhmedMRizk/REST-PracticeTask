using Microsoft.EntityFrameworkCore;
using RestPracticeTask.API.Entities;

namespace RestPracticeTask.API.DbContexts
{
    public class PracticeAppContext : DbContext
    {
        public PracticeAppContext(DbContextOptions<PracticeAppContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(24,4)");
            // seed the database with dummy data
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = Guid.Parse("324F1A6A-B551-4A5A-A852-09FAE0DBBC2A"),
                    Name = "Honda T360",
                    Price = 500000,
                    Quantity = 2,
                    CategoryId = Guid.Parse("DFEF3A8C-A6E2-4C54-89AA-CDCDEED7EC09"),
                    ImgUrl =
                        "https://en.wikipedia.org/wiki/Honda#/media/File:Honda_T360_1963_in_Honda_Collection_Hall.jpg"
                },
                new Product()
                {
                    Id = Guid.Parse("6A275163-8D3E-491C-9BB0-C49026519070"),
                    Name = "BMW X2",
                    Price = 800000,
                    Quantity = 3,
                    CategoryId = Guid.Parse("DFEF3A8C-A6E2-4C54-89AA-CDCDEED7EC09"),
                    ImgUrl =
                        "https://en.wikipedia.org/wiki/BMW#/media/File:2018_BMW_X2_xDrive20D_M_Sport_X_Automatic_2.0.jpg"
                },
                new Product()
                {
                    Id = Guid.Parse("DD623036-E8FC-44D7-B8ED-4C7D4ABA84EB"),
                    Name = "Mercedes S-Class",
                    Price = 1500000,
                    Quantity = 6,
                    CategoryId = Guid.Parse("DFEF3A8C-A6E2-4C54-89AA-CDCDEED7EC09"),
                    ImgUrl = "https://en.wikipedia.org/wiki/Mercedes-Benz#/media/File:Mercedes-Benz_W223_IMG_3951.jpg"
                },
                new Product()
                {
                    Id = Guid.Parse("F96E8BF1-606B-47B0-9805-55442D4CBCDB"),
                    Name = "Samsung TV",
                    Price = 5211,
                    Quantity = 55,
                    CategoryId = Guid.Parse("AC12210A-1419-49D6-8F4B-DA20B0DDD10F"),
                    ImgUrl =
                        "https://en.wikipedia.org/wiki/Samsung_Electronics#/media/File:Samsung_UN105S9_20140127.jpg"
                },
                new Product()
                {
                    Id = Guid.Parse("049ABED8-0458-45A9-BA41-2D95FC45152D"),
                    Name = "Old Sharp TV",
                    Price = 335,
                    Quantity = 1,
                    CategoryId = Guid.Parse("AC12210A-1419-49D6-8F4B-DA20B0DDD10F"),
                    ImgUrl = "https://en.wikipedia.org/wiki/Sharp_Corporation#/media/File:Sharp_C1_NES_TV_14C-C1F.png"
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("DFEF3A8C-A6E2-4C54-89AA-CDCDEED7EC09"),
                    Name = "Cars"
                },
                new Category
                {
                    Id = Guid.Parse("AC12210A-1419-49D6-8F4B-DA20B0DDD10F"),
                    Name = "TVs"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}