using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class PetDbContext : DbContext
    {
        private readonly string _connectionString;
        public PetDbContext()
        {
            _connectionString = "Server =.\\SQLEXPRESS; Database = CSharpB15; User Id = csharpb15; Password = 1111; Trust Server Certificate = True";
        }

        //Db Sets
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Aquarium> Aquarium { get; set; }
        public DbSet<SalePet> SalePets { get; set; }
        public DbSet<PetPurchaseRecord> PetPurchaseRecords { get; set; }

        public DbSet<FeedingSchedule> feedingSchedules { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
            base.OnConfiguring(optionsBuilder);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //seeding
            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                Name = "Admin",
                UserName = "admin",
                Password = "123456"
            });

            modelBuilder.Entity<Cage>().ToTable("Cage");
            
            modelBuilder.Entity<Pet>().ToTable("Pets");
            modelBuilder.Entity<SalePet>().ToTable("SalePets");
            modelBuilder.Entity<PetPurchaseRecord>().ToTable("PetPurchase");

            modelBuilder.Entity<Cage>()
                .HasMany(c => c.Pets)
                .WithOne(p => p.Cage).HasForeignKey(y => y.CageId);


           

            modelBuilder.Entity<Aquarium>()
                .HasMany(a => a.Fish)
                .WithOne(p => p.Aquarium).HasForeignKey(y => y.AquariumId);

            modelBuilder.Entity<SalePet>()
                .HasOne(sp => sp.Pet)
                .WithMany(p => p.SalePet)
                .HasForeignKey(sp => sp.PetId);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Cage)
                .WithMany(c => c.Feedings)
                .HasForeignKey(fs => fs.CageId);


            base.OnModelCreating(modelBuilder);
        }


    }
}
