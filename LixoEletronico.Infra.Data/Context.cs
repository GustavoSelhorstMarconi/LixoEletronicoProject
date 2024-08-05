using LixoEletronico.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LixoEletronico.Infra.Data
{
    public class Context : IdentityDbContext<Person, IdentityRole<int>, int>
    {
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Address> Adresses { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .Property(x => x.Name).HasColumnType("varchar(300)");

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Companies)
                .WithOne(x => x.Representant)
                .HasForeignKey(x => x.RepresentantId)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<Company>(x => x.AddressId)
                .IsRequired(true);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.PersonId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
