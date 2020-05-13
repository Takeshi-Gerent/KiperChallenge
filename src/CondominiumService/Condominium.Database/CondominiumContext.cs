using Auth.Api.Domain;
using Condominium.Core.Domain;
using Condominium.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Condominium.Database
{
    public class CondominiumContext: DbContext
    {
        public CondominiumContext(DbContextOptions<CondominiumContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Dweller> Dweller { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.UserName).IsRequired().HasColumnType("varchar(20)");
                entity.Property(e => e.Password).IsRequired().HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Number).IsRequired();
                entity.Property(e => e.Block).HasColumnType("varchar(5)");
                entity.HasMany(d => d.Dwellers).WithOne(p => p.Apartment);
            });

            modelBuilder.Entity<Dweller>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnType("varchar(40)");
                entity.Property(e => e.BirthDate);
                entity.Property(e => e.Telephone).HasColumnType("varchar(15)");
                entity.Property(e => e.CPF).HasColumnType("varchar(40)");
                entity.Property(e => e.Email).HasColumnType("varchar(40)");
            });

            modelBuilder.Seed();            
        }
    }
}
