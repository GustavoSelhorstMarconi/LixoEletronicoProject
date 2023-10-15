using LixoEletronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LixoEletronico.Infra.Data
{
    public class Context : DbContext
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
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId)
                .IsRequired(true);

            modelBuilder.Entity<Company>()
                .HasOne(x => x.Representant)
                .WithOne()
                .HasForeignKey<Company>(x => x.RepresentantId)
                .IsRequired(true);

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
        }
    }
}
