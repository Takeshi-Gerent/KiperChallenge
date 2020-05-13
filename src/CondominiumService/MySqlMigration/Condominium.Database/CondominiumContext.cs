using Auth.Api.Domain;
using Condominium.Core.Domain;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;


namespace Condominium.Database
{
    public class CondominiumContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Dweller> Dweller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;userid=root;pwd=Pass1234;port=3306;database=Condominium;sslmode=none;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserName).IsRequired(); ;
                entity.Property(e => e.Password).IsRequired(); ;
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Number).IsRequired();
                entity.Property(e => e.Block);
                entity.HasMany(d => d.Dwellers).WithOne(p => p.Apartment);
            });

            modelBuilder.Entity<Dweller>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.BirthDate);
                entity.Property(e => e.Telephone);
                entity.Property(e => e.CPF);
                entity.Property(e => e.Email);
            });        
        }
    }
}
